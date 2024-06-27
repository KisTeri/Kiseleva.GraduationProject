using iText.Svg.Renderers.Path.Impl;
using Kiseleva.GraduationProject.Data;
using Kiseleva.GraduationProject.Entities;
using Kiseleva.GraduationProject.Interfaces;
using Kiseleva.GraduationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using File = Kiseleva.GraduationProject.Entities.File;
using X.PagedList;


namespace Kiseleva.GraduationProject.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IPersonRepository _personRepository;

		[BindProperty]
		public CardPersonViewModel CardViewModel { get; set; }

		public PersonController(ILogger<HomeController> logger, ApplicationDbContext context, IPersonRepository personRepository)
        {
            _logger = logger;
            _context = context;
            _personRepository = personRepository;
        }

        [HttpGet]
        [Route("Students")]
        public async Task<IActionResult> Index(string searchString, string currentFilter, string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
         
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var people = from p in _context.Persons.Where(p => p.DateOfBirth != null) // возможно, прописать новый метод в интерфейсе
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                people = people.Where(p => p.LastName.Contains(searchString) || p.FirstName.Contains(searchString) || p.MiddleName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    people = people.OrderByDescending(s => s.LastName);
                    break;
                default:
                    people = people.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(people.ToPagedList(pageNumber, pageSize));
        }

        [Route("Students/PersonalInformation/{id}")]
        public async Task<IActionResult> Card(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personRepository.GetByIdAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            var viewModel = new CardPersonViewModel
            {
                Id = id,
                LastName = person.LastName,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                DateOfBirth = person.DateOfBirth,
                PhoneNumber = person.PhoneNumber,
                Series = person.DocumentsOfPerson.First().Series,
                Number = person.DocumentsOfPerson.First().Number,
                IssuedBy = person.DocumentsOfPerson.First().IssuedBy,
                IssuedWhen = person.DocumentsOfPerson.First().IssuedWhen,
                SNILS = person.DocumentsOfPerson.First().SNILS,
                Address = person.Address,
                Files = await _context.Files.Where(x => x.PersonId == id).ToListAsync(),
            };
			return View(viewModel);
            
        }

        [HttpGet]
        public async Task<IActionResult> _File(int id)
        {
            if (id == null) return NotFound();

            var people = await _context.Persons.Include(x => x.Files).FirstOrDefaultAsync(x => x.Id == id);

            var vm = new CardWithFiles
            {
                PersonId = people.Id,
                CardPerson = people,
                Files = people.Files
            };

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> _File(IFormFile file, int id)
        {
            

            byte[] bytes;
            using (BinaryReader br = new BinaryReader(file.OpenReadStream()))
            {
                bytes = br.ReadBytes((int)file.Length);
            }

            using (SqlConnection connection = new SqlConnection())
            {
                //connection.ConnectionString =
                //  "Data Source=localhost\\SQLEXPRESS;" +
                //  "Initial Catalog=VolgStoiDb;" +
                //  "Integrated Security=SSPI;" +
                //  "Trusted_Connection = true;" +
                //              "TrustServerCertificate = true;";

                connection.ConnectionString =
                  "Data Source=KISELEVAE;" +
                  "Initial Catalog=VolgStoiDb;" +
                  "Integrated Security=SSPI;" +
                  "Trusted_Connection = true;" +
                  "TrustServerCertificate = true;";

                string query = "INSERT INTO Files (FileName, ContentType, Data, PersonId) VALUES (@FileName, @ContentType, @Data, @PersonId)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@FileName", Path.GetFileName(file.FileName));
                    cmd.Parameters.AddWithValue("@ContentType", file.ContentType);
                    cmd.Parameters.AddWithValue("@Data", bytes);
                    cmd.Parameters.AddWithValue("@PersonId", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

			//return RedirectToAction("Card", new {id});
            return RedirectToAction("Index");
        }


        public ActionResult File()
        {
            return PartialView("_File");
        }


        [HttpGet]
        public async Task<IActionResult> CreatePerson()
        {
            var createPersonViewModel = new CreatePersonViewModel();
            return View(createPersonViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(CreatePersonViewModel createPersonViewModel)
        {
            if (ModelState.IsValid)
            {
                var doc = new DocumentOfPerson
                {
                    Series = createPersonViewModel.Series,
                    Number = createPersonViewModel.Number,
                    IssuedBy = createPersonViewModel.IssuedBy,
                    IssuedWhen = createPersonViewModel.IssuedWhen,
                    SNILS = createPersonViewModel.SNILS,

                    Person = new Person
                    {
                        LastName = createPersonViewModel.Person.LastName,
                        FirstName = createPersonViewModel.Person.FirstName,
                        MiddleName = createPersonViewModel.Person.MiddleName,
                        DateOfBirth = createPersonViewModel.Person.DateOfBirth,
                        PhoneNumber = createPersonViewModel.Person.PhoneNumber,
                        KindOfPerson = createPersonViewModel.Person.KindOfPerson,

                        Address = new Address
                        {
                            Region = createPersonViewModel.Person.Address.Region,
                            District = createPersonViewModel.Person.Address.District,
                            Settlement = createPersonViewModel.Person.Address.Settlement,
                            Street = createPersonViewModel.Person.Address.Street,
                            Building = createPersonViewModel.Person.Address.Building,
                            Apartment = createPersonViewModel.Person.Address.Apartment,
                        }
                    },

                    KindOfDocument = new KindOfDocument
                    {
                        Kind = createPersonViewModel.KindOfDocument.Kind
                    }
                };

                _personRepository.Add(doc);
                _personRepository.Save();

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Ошибка добавления нового ученика");
            }

            return View(createPersonViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditPerson(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personRepository.GetByIdAsync(id);

            if (person == null) return NotFound();

            var editPersonVM = new EditPersonViewModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                DateOfBirth = person.DateOfBirth,
                PhoneNumber = person.PhoneNumber,
                KindOfPerson = person.KindOfPerson,
                Series = person.DocumentsOfPerson.First().Series,
                Number = person.DocumentsOfPerson.First().Number,
                IssuedBy = person.DocumentsOfPerson.First().IssuedBy,
                IssuedWhen = person.DocumentsOfPerson.First().IssuedWhen,
                SNILS = person.DocumentsOfPerson.First().SNILS,
                AddressId = person.AddressId,
                Address = person.Address,
                DocumentsOfPerson = person.DocumentsOfPerson,
            };
            return View(editPersonVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditPerson(int id, EditPersonViewModel editPersonViewModel)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Ошибка сохранения");
                return View(editPersonViewModel);
            }

            var person = new Person
            {
                Id = id,
                LastName = editPersonViewModel.LastName,
                FirstName = editPersonViewModel.FirstName,
                MiddleName = editPersonViewModel.MiddleName,
                DateOfBirth = editPersonViewModel.DateOfBirth,
                PhoneNumber = editPersonViewModel.PhoneNumber,
                KindOfPerson = editPersonViewModel.KindOfPerson,
                AddressId = editPersonViewModel.AddressId,
                Address = editPersonViewModel.Address,
                DocumentsOfPerson = editPersonViewModel.DocumentsOfPerson,
            };

            _personRepository.Update(person);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
			if (id == null)
			{
				return NotFound();
			}

			var person = await _personRepository.GetByIdAsync(id);
            if (person == null) return NotFound();

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (id == null) return NotFound();

            var person = await _personRepository.GetByIdForRemovingAsync(id);

            if (person == null) return NotFound();

            _personRepository.Delete(person);
            _personRepository.Save();
            return RedirectToAction("Index");
        }

        private static List<File> GetFiles()
        {
            List<File> files = new List<File>();

            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, FileName FROM Files"))
                {
                    //connection.ConnectionString =
                    //     "Data Source=localhost\\SQLEXPRESS;" +
                    //     "Initial Catalog=VolgStoiDb;" +
                    //     "Integrated Security=SSPI;" +
                    //     "Trusted_Connection = true;" +
                    //     "TrustServerCertificate = true;";

                    connection.ConnectionString =
                      "Data Source=KISELEVAE;" +
                      "Initial Catalog=VolgStoiDb;" +
                      "Integrated Security=SSPI;" +
                      "Trusted_Connection = true;" +
                      "TrustServerCertificate = true;";

                    cmd.Connection = connection;
                    connection.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            files.Add(new File
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                FileName = sdr["FileName"].ToString()
                            });
                        }
                    }
                    connection.Close();
                }
            }
            return files;
        }

        private static File GetFile()
        {
            File file = new File();

            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, FileName FROM Files"))
                {
                    //connection.ConnectionString =
                    //  "Data Source=localhost\\SQLEXPRESS;" +
                    //  "Initial Catalog=VolgStoiDb;" +
                    //  "Integrated Security=SSPI;" +
                    //  "Trusted_Connection = true;" +
                    //  "TrustServerCertificate = true;";

                    connection.ConnectionString =
                      "Data Source=KISELEVAE;" +
                      "Initial Catalog=VolgStoiDb;" +
                      "Integrated Security=SSPI;" +
                      "Trusted_Connection = true;" +
                      "TrustServerCertificate = true;";

                    cmd.Connection = connection;
                    connection.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            file = new File
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                FileName = sdr["FileName"].ToString()
                            };
                        }
                    }
                    connection.Close();
                }
            }
            return file;
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
            byte[] bytes;
            string fileName, contentType;

            using (SqlConnection connection = new SqlConnection())
            {
                //connection.ConnectionString =
                //  "Data Source=localhost\\SQLEXPRESS;" +
                //  "Initial Catalog=VolgStoiDb;" +
                //  "Integrated Security=SSPI;" +
                //  "Trusted_Connection = true;" +
                //  "TrustServerCertificate = true;";

                connection.ConnectionString =
                      "Data Source=KISELEVAE;" +
                      "Initial Catalog=VolgStoiDb;" +
                      "Integrated Security=SSPI;" +
                      "Trusted_Connection = true;" +
                      "TrustServerCertificate = true;";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT FileName, Data, ContentType FROM Files WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", fileId);
                    cmd.Connection = connection;
                    connection.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["FileName"].ToString();
                    }
                    connection.Close();
                }
            }

            return File(bytes, contentType, fileName);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFile(int? id)
        {
            if (id != null)
            {
                var file = await _context.Files.FirstOrDefaultAsync(x => x.Id == id);
                if (file != null)
                {
                    _context.Files.Remove(file);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                    //return PartialView("_File");
				}
            }
            return NotFound();
        }
    }
}