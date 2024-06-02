using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestPdfMVC.Models;

namespace TestPdfMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		//public IActionResult Index()
		//{
		//          string pdfPath = "example";

		//	byte[] pdfBytes;
		//	var memoryStream = new MemoryStream();

		//          PdfWriter writer = new PdfWriter(memoryStream);
		//          writer.SetCloseStream(false);
		//          PdfDocument pdf = new PdfDocument(writer);
		//	Document document = new Document(pdf);
		//	Paragraph p = new Paragraph("Hello");
		//	document.Add(p);
		//	document.Close();


		//	pdfBytes = memoryStream.ToArray();
		//	memoryStream.Write(pdfBytes, 0, pdfBytes.Length);
		//	memoryStream.Position = 0;

		//	FileStreamResult fileStreamResult = new FileStreamResult(memoryStream, "application/pdf");

		//	fileStreamResult.FileDownloadName = "Договор.pdf";

		//	return fileStreamResult;

		//	//return View(memoryStream.ToArray());
		//      }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
