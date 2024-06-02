using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.Layout.Properties;
using iText.StyledXmlParser.Jsoup.Nodes;


//var font = PdfFontFactory.CreateFont("timesnewromanpsmt.ttf", PdfEncodings.IDENTITY_H);

//using (PdfWriter writer = new PdfWriter("Contract.pdf"))
//using(PdfDocument pdfDoc = new PdfDocument(writer))
//using(var document = new iText.Layout.Document(pdfDoc))
//{
//    pdfDoc.GetCatalog().SetLang(new PdfString("ru-RU"));
//    pdfDoc.AddFont(font);
//    document.SetMargins(45, 40, 40, 70);

//    Paragraph heading = new Paragraph("Договор № 1").SetTextAlignment(TextAlignment.CENTER).SetFont(font).SetFontSize(14).SetBold();
//    document.Add(heading);

//    Paragraph subheading = new Paragraph("о предоставлении платных образовательных услуг").SetTextAlignment(TextAlignment.CENTER).SetFont(font).SetFontSize(12).SetBold();
//    document.Add(subheading);

//    Paragraph data = new Paragraph();
//    data.Add("«___»________2024г.").SetTextAlignment(TextAlignment.LEFT).SetFont(font).SetFontSize(12);
//    data.Add(new Text("                                                                                                      " + "г.Волгодонск")).SetFont(font).SetFontSize(12);
//    document.Add(data);

//    Paragraph firstParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED);
//    firstParagraph.Add(new Text("Частное образовательное учреждение дополнительного профессионального «Учебный центр «Волгодонскстрой»").SetBold()).SetFont(font).SetFontSize(12).SetFirstLineIndent(25);
//    firstParagraph.Add(" в лице Исполнительного директора Валентейчик Татьяны Владимировны, действующей на основании доверенности № 1А от 09.01.2023г. и Лицензии на осуществление образовательной деятельности ").SetFont(font).SetFontSize(12);
//    firstParagraph.Add(new Text("№ Л035-01276-61/00286753 от 14.05.2015г.").SetBold()).SetFont(font).SetFontSize(12);
//    firstParagraph.Add(", именуемое в дальнейшем ").SetFont(font).SetFontSize(12);
//    firstParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой»").SetBold()).SetFont(font).SetFontSize(12);
//    firstParagraph.Add(", с одной стороны и учащийся ФИО УЧАЩЕГОСЯ !!!!").SetFont(font).SetFontSize(12);
//    firstParagraph.Add(", именуемый в дальнейшем ").SetFont(font).SetFontSize(12);
//    firstParagraph.Add(new Text("«ЗАКАЗЧИК» ").SetBold()).SetFont(font).SetFontSize(12);
//    firstParagraph.Add("заключили настоящий Договор о нижеследующем:").SetFont(font).SetFontSize(12);
//    document.Add(firstParagraph);

//    Paragraph headingSecondParagraph = new Paragraph().SetTextAlignment(TextAlignment.CENTER);
//    headingSecondParagraph.Add(new Text("I. ПРЕДМЕТ ДОГОВОРА").SetBold()).SetFont(font).SetFontSize(12);
//    document.Add(headingSecondParagraph);

//    Paragraph secondParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED);
//    secondParagraph.Add("1.1. ").SetFont(font).SetFontSize(12);
//    secondParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold()).SetFont(font).SetFontSize(12);
//    secondParagraph.Add("оказывает образовательные услуги (подготовка, переподготовка, повышение квалификации, аттестация, повторная проверка знаний) по избранной ").SetFont(font).SetFontSize(12);
//    secondParagraph.Add(new Text("«ЗАКАЗЧИКОМ» ").SetBold()).SetFont(font).SetFontSize(12);
//    secondParagraph.Add("программе профессионального обучения - НАЗВАНИЕ ПРОГРАММЫ ОБУЧЕНИЯ!!! в соответствии с Лицензией, Учебным планом и Уставом ЧОУ ДПО «УЦ «Волгодонскстрой».").SetFont(font).SetFontSize(12);
//    document.Add(secondParagraph);

//    Paragraph headingThirdParagraph = new Paragraph().SetTextAlignment(TextAlignment.CENTER);
//    headingThirdParagraph.Add(new Text("II. ЦЕЛЬ ДОГОВОРА").SetBold()).SetFont(font).SetFontSize(12);
//    document.Add(headingThirdParagraph);

//    Paragraph thirdParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED);
//    thirdParagraph.Add("2.1. Целью договора является профессиональное обучение ").SetFont(font).SetFontSize(12);
//    thirdParagraph.Add(new Text("«ЗАКАЗЧИКА» ").SetBold()).SetFont(font).SetFontSize(12);
//    thirdParagraph.Add("или получение заказчиком дополнительного профессионального образования. ").SetFont(font).SetFontSize(12);
//    document.Add(thirdParagraph);

//    Paragraph headingFourthParagraph = new Paragraph().SetTextAlignment(TextAlignment.CENTER);
//    headingFourthParagraph.Add(new Text("III. ОБЯЗАННОСТИ СТОРОН").SetBold()).SetFont(font).SetFontSize(12);
//    document.Add(headingFourthParagraph);

//    Paragraph fourthParagraph = new Paragraph();
//    fourthParagraph.Add("3.1. ").SetFont(font).SetFontSize(12);
//    fourthParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold()).SetFont(font).SetFontSize(12);
//    fourthParagraph.Add("обязуется:").SetFont(font).SetFontSize(12).SetFixedLeading(5);
//    document.Add(fourthParagraph);

//    Paragraph fourthSubparagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17).SetFirstLineIndent(35);
//    fourthSubparagraph.Add("3.1.1. До заключения настоящего Договора ознакомить ").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fourthSubparagraph.Add(new Text("«ЗАКАЗЧИКА» ").SetBold()).SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fourthSubparagraph.Add("с программой обучения, расписанием занятий, списком требуемой литературы, учебно-материальной базой ").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fourthSubparagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой», ").SetBold()).SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fourthSubparagraph.Add("условиями оплаты.").SetFont(font).SetFontSize(12);
//    document.Add(fourthSubparagraph);

//    Paragraph fourthSubparagraph2 = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17).SetFirstLineIndent(35);
//    fourthSubparagraph2.Add("3.1.2. Обеспечить ").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fourthSubparagraph2.Add(new Text("«ЗАКАЗЧИКУ» ").SetBold()).SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fourthSubparagraph2.Add("высокий уровень преподавания и выполнение всех требований по охране труда, технике безопасности, выполнение санитарно-гигиенических норм, соблюдение его прав, защиты чести и достоинства.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(fourthSubparagraph2);

//    Paragraph fourthSubparagraph3 = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17).SetFirstLineIndent(35);
//    fourthSubparagraph3.Add("3.1.3. Предоставить ").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fourthSubparagraph3.Add(new Text("«ЗАКАЗЧИКУ» ").SetBold()).SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fourthSubparagraph3.Add("возможность пользоваться учебно-материальной базой.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(fourthSubparagraph3);

//    Paragraph fifthParagraph = new Paragraph();
//    fifthParagraph.Add("3.2. ").SetFont(font).SetFontSize(12);
//    fifthParagraph.Add(new Text("«ЗАКАЗЧИК» ").SetBold()).SetFont(font).SetFontSize(12);
//    fifthParagraph.Add("обязуется:").SetFont(font).SetFontSize(12).SetFixedLeading(5);
//    document.Add(fifthParagraph);

//    Paragraph fifthSubparagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17).SetFirstLineIndent(35);
//    fifthSubparagraph.Add("3.2.1. Посещать учебные занятия в соответствии  с расписанием, выполнять распорядок дня ").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fifthSubparagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой», ").SetBold()).SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fifthSubparagraph.Add("иметь опрятный внешний вид, убирать рабочее место по окончании практических занятий.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(fifthSubparagraph);

//    Paragraph fifthSubparagraph2 = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17).SetFirstLineIndent(35);
//    fifthSubparagraph2.Add("3.2.2. Знать и выполнять требования по технике безопасности и охране труда.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(fifthSubparagraph2);

//    Paragraph fifthSubparagraph3 = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17).SetFirstLineIndent(35);
//    fifthSubparagraph3.Add("3.2.3. Возмещать ").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fifthSubparagraph3.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold()).SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fifthSubparagraph3.Add("материальный ущерб, нанесенный по вине ").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fifthSubparagraph3.Add(new Text("«ЗАКАЗЧИКА», ").SetBold()).SetFont(font).SetFontSize(12);
//    fifthSubparagraph3.Add("восстанавливать испорченное оборудование, инвентарь.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(fifthSubparagraph3);

//    Paragraph fifthSubparagraph4 = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17).SetFirstLineIndent(35);
//    fifthSubparagraph4.Add("3.2.4. Произвести оплату за обучение в кассу ").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fifthSubparagraph4.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой».").SetBold()).SetFont(font).SetFontSize(12).SetFixedLeading(17);  
//    document.Add(fifthSubparagraph4);

//    Paragraph headingFifthParagraph = new Paragraph().SetTextAlignment(TextAlignment.CENTER);
//    headingFifthParagraph.Add(new Text("IV. ПРАВА СТОРОН").SetBold()).SetFont(font).SetFontSize(12);
//    document.Add(headingFifthParagraph);

//    Paragraph sixthParagraph = new Paragraph();
//    sixthParagraph.Add("4.1. ").SetFont(font).SetFontSize(12);
//    sixthParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold()).SetFont(font).SetFontSize(12);
//    sixthParagraph.Add("имеет право:").SetFont(font).SetFontSize(12).SetFixedLeading(5);
//    document.Add(sixthParagraph);

//    Paragraph sixthSubparagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17).SetFirstLineIndent(35);
//    sixthSubparagraph.Add("4.1.1. Подбирать, разрабатывать и применять программы и методики обучения.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(sixthSubparagraph);

//    Paragraph sixthSubparagraph2 = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17).SetFirstLineIndent(35);
//    sixthSubparagraph2.Add("4.1.2. Заменять преподавателя и изменять количество учебных часов в пределлах прорграммы.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(sixthSubparagraph2);

//    Paragraph seventhParagraph = new Paragraph();
//    seventhParagraph.Add("4.2. ").SetFont(font).SetFontSize(12);
//    seventhParagraph.Add(new Text("«ЗАКАЗЧИК» ").SetBold()).SetFont(font).SetFontSize(12);
//    seventhParagraph.Add("имеет право:").SetFont(font).SetFontSize(12).SetFixedLeading(5);
//    document.Add(seventhParagraph);

//    Paragraph sevenSubparagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17).SetFirstLineIndent(35);
//    sevenSubparagraph.Add("4.2.1. Знакомиться с программой обучения, расписанием, календарным графиком, образовательным процессом, условиями прохождения производственной практики, условиями итоговой аттестации - квалификационного экзамена.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(sevenSubparagraph);

//    Paragraph headingEightParagraph = new Paragraph().SetTextAlignment(TextAlignment.CENTER);
//    headingEightParagraph.Add(new Text("V. ПОРЯДОК ОПЛАТЫ").SetBold()).SetFont(font).SetFontSize(12);
//    document.Add(headingEightParagraph);

//    Paragraph eightthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17);
//    eightthParagraph.Add("5.1. Стоимость предоставляемых образовательных услуг соответствует смете расхода на текущий период и на момент заполнения договора составляет: ЦЕНА!!! руб.").SetFont(font).SetFontSize(12).SetFixedLeading(17); 
//    document.Add(eightthParagraph);

//    Paragraph ninethParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17);
//    ninethParagraph.Add("5.2. Допускается индексирование стоимости услуг с начала любого календарного месяца по ").SetFont(font).SetFontSize(12).SetFixedLeading(17); 
//    ninethParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold()).SetFont(font).SetFontSize(12).SetFixedLeading(17); 
//    ninethParagraph.Add("с учетом инфляции и роста цен. Новая стоимость согласуется сторонами в письменном виде и является основой настоящего договора.").SetFont(font).SetFontSize(12).SetFixedLeading(17); 
//    document.Add(ninethParagraph);

//    Paragraph tenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17);
//    tenthParagraph.Add("5.3. В случае, если занятия пропущены ").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    tenthParagraph.Add(new Text("«ЗАКАЗЧИКОМ» ").SetBold()).SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    tenthParagraph.Add("по уважительной причине(болезнь, похороны) подтверждающими документами, ").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    tenthParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold()).SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    tenthParagraph.Add("организует индивидуальные консультации.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(tenthParagraph);

//    Paragraph eleventhParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17);
//    eleventhParagraph.Add("5.4. При расторжении настоящего договора по инициативе ").SetFont(font).SetFontSize(12).SetFixedLeading(17); 
//    eleventhParagraph.Add(new Text("«ЗАКАЗЧИКА» ").SetBold()).SetFont(font).SetFontSize(12).SetFixedLeading(17); 
//    eleventhParagraph.Add("перерасчет оплаты осуществляется пропорционально времени, затраченному на обучение и дополнительным удержанием 30% на издержки.").SetFont(font).SetFontSize(12).SetFixedLeading(17); 
//    document.Add(eleventhParagraph);

//    Paragraph headingTwelveParagraph = new Paragraph().SetTextAlignment(TextAlignment.CENTER);
//    headingTwelveParagraph.Add(new Text("VI. СРОК ДОГОВОРА").SetBold()).SetFont(font).SetFontSize(12);
//    document.Add(headingTwelveParagraph);

//    Paragraph twelvethParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17);
//    twelvethParagraph.Add("6.1. Настоящий договор вступает в силу с момента подписания и действует до окончания срока обучения.").SetFont(font).SetFontSize(12).SetFixedLeading(17); 
//    document.Add(twelvethParagraph);

//    Paragraph thirteenththParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17);
//    thirteenththParagraph.Add("6.2. До истечения срока, договор, может быть, расторгнут по инициативе «Заказчика», о чем он предупреждает администрацию в письменном виде не позднее, чем за 2 недели.").SetFont(font).SetFontSize(12).SetFixedLeading(17); 
//    document.Add(thirteenththParagraph);

//    Paragraph fourteenththParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17);
//    fourteenththParagraph.Add("6.3. Договор, может быть, расторгнут досрочно по инициативе ").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fourteenththParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold()).SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    fourteenththParagraph.Add("при неуплате за обучение.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(fourteenththParagraph);

//    Paragraph headingFifteenParagraph = new Paragraph().SetTextAlignment(TextAlignment.CENTER);
//    headingFifteenParagraph.Add(new Text("VII. ДОПОЛНИТЕЛЬНЫЕ УСЛОВИЯ").SetBold()).SetFont(font).SetFontSize(12);
//    document.Add(headingFifteenParagraph);

//    Paragraph fifteenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17);
//    fifteenthParagraph.Add("7.1. Настоящий договор составлен в двух экземплярах, имеющих равную юридическую силу, по одному экземпляру для каждой стороны.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(fifteenthParagraph);

//    Paragraph sixteenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17);
//    sixteenthParagraph.Add("7.2. Все изменения и дополнения к договору оформляются в письменном виде.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(sixteenthParagraph);

//    Paragraph headingSeventeenParagraph = new Paragraph().SetTextAlignment(TextAlignment.CENTER);
//    headingSeventeenParagraph.Add(new Text("VIII. ОТВЕТСТВЕННОСТЬ СТОРОН").SetBold()).SetFont(font).SetFontSize(12);
//    document.Add(headingSeventeenParagraph);

//    Paragraph seventeenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17);
//    seventeenthParagraph.Add("8.1. Ответственность сторон за невыполнение или ненадлежащее выполнение обязательств по договору определяется в соответствии с гражданским законодательством.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(seventeenthParagraph);

//    Paragraph eighteenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetFixedLeading(17);
//    eighteenthParagraph.Add("8.2. Споры, возникшие при заключении договора, разрешаются в установленном законодательством порядке.").SetFont(font).SetFontSize(12).SetFixedLeading(17);
//    document.Add(eighteenthParagraph);

//    Paragraph headingNineteenParagraph = new Paragraph().SetTextAlignment(TextAlignment.CENTER);
//    headingNineteenParagraph.Add(new Text("IX. ЮРИДИЧЕСКИЕ АДРЕСА СТОРОН").SetBold()).SetFont(font).SetFontSize(12);
//    document.Add(headingNineteenParagraph);


//    Table table = new Table(2).SetTextAlignment(TextAlignment.JUSTIFIED);

//    Paragraph name = new Paragraph("ЧОУ ДПО «УЦ «Волгодонскстрой»");
//    Paragraph address = new Paragraph("347366, г.Волгодонск ул.Волгодонская 16");
//    Paragraph OGRN = new Paragraph("ОГРН 1056143066297");
//    Paragraph INN = new Paragraph("ИНН 6143060182");
//    Paragraph KPP = new Paragraph("КПП 614301001");
//    Paragraph director = new Paragraph("Исполнительный директор_____________");
//    Paragraph FIODirector = new Paragraph("Валентейчик Т.В.");

//    Paragraph namePerson = new Paragraph("«ЗАКАЗЧИК»");
//    Paragraph FIO = new Paragraph("Ф.И.О.");
//    Paragraph dateOfBirthday = new Paragraph("Дата рождения");
//    Paragraph passport = new Paragraph("Паспорт: серия,№");
//    Paragraph issuedBy = new Paragraph("Кем выдан");
//    Paragraph issuedWhen = new Paragraph("Когда выдан");
//    Paragraph addressPerson = new Paragraph("Адрес проживания");
//    Paragraph phone = new Paragraph("Телефон");
//    Paragraph sign = new Paragraph("Подпись______________");

//    Cell column1 = new Cell().Add(name.SetBold()).SetFont(font).SetFontSize(12).SetWidth(240);
//    column1.Add(address).SetFont(font).SetFontSize(12);
//    column1.Add(OGRN).SetFont(font).SetFontSize(12);
//    column1.Add(INN).SetFont(font).SetFontSize(12);
//    column1.Add(KPP.SetMarginBottom(20)).SetFont(font).SetFontSize(12);
//    column1.Add(director.SetBold().SetItalic()).SetFont(font).SetFontSize(12);
//    column1.Add(FIODirector.SetMarginLeft(135)).SetFont(font).SetFontSize(12);
//    table.AddCell(column1);

//    Cell column2 = new Cell().Add(namePerson.SetBold().SetMarginBottom(10)).SetFont(font).SetFontSize(12).SetWidth(240);
//    column2.Add(FIO.SetBold()).SetFont(font).SetFontSize(12);
//    column2.Add(dateOfBirthday.SetMarginBottom(10)).SetFont(font).SetFontSize(12);
//    column2.Add(passport).SetFont(font).SetFontSize(12);
//    column2.Add(issuedBy).SetFont(font).SetFontSize(12);
//    column2.Add(issuedWhen).SetFont(font).SetFontSize(12);
//    column2.Add(addressPerson).SetFont(font).SetFontSize(12);
//    column2.Add(phone.SetMarginBottom(10)).SetFont(font).SetFontSize(12);
//    column2.Add(sign).SetFont(font).SetFontSize(12);
//    table.AddCell(column2);

//    document.Add(table);

//    document.Close();
//}


var font = PdfFontFactory.CreateFont("timesnewromanpsmt.ttf", PdfEncodings.IDENTITY_H);

using (PdfWriter writer = new PdfWriter("Contract.pdf"))
using (PdfDocument pdfDoc = new PdfDocument(writer))
using (var document = new iText.Layout.Document(pdfDoc))
{
    pdfDoc.GetCatalog().SetLang(new PdfString("ru-RU"));
    pdfDoc.AddFont(font);
    document.SetMargins(45, 40, 40, 70);
    document.SetFont(font).SetFontSize(12);

    Paragraph heading = new Paragraph("Договор № 1").SetTextAlignment(TextAlignment.CENTER).SetBold();
    document.Add(heading);

    Paragraph data = new Paragraph();
    data.Add("г.Волгодонск").SetTextAlignment(TextAlignment.LEFT);
    data.Add(new Text("                                                                                                      " + "«___»________2024г."));
    document.Add(data);

    Paragraph firstParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED);
    firstParagraph.Add(new Text("Частное образовательное учреждение дополнительного профессионального «Учебный центр «Волгодонскстрой»").SetBold()).SetFirstLineIndent(25);
    firstParagraph.Add(", (ЧОУ ДПО «УЦ «Волгодонскстрой») в лице Исполнительного директора Валентейчик Татьяны Владимировны, действующей на основании Доверенности № 1А от 09.01.2023г. и Лицензии на осуществление образовательной деятельности ");
    firstParagraph.Add(new Text("№ Л035-01276-61/00286753 от 14.05.2015г.").SetBold());
    firstParagraph.Add(", именуемое в дальнейшем ");
    firstParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой»").SetBold());
    firstParagraph.Add(" с одной стороны, и Название организации!!!! в лице Название должности!!!! ФИО!!!!, действующим на основании ?????, именуемый в дальнейшем");
    firstParagraph.Add(new Text("«Заказчик» ").SetBold());
    firstParagraph.Add("заключили настоящий Договор о нижеследующем:").SetPaddingBottom(5.5f);
    document.Add(firstParagraph);

    Paragraph secondHeading = new Paragraph().SetTextAlignment(TextAlignment.CENTER).SetMarginTop(0f).SetMarginBottom(0f);
    secondHeading.Add(new Text("1. Предмет договора").SetBold());
    document.Add(secondHeading);

    Paragraph secondParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    secondParagraph.Add("1.1. ").SetFirstLineIndent(25);
    secondParagraph.Add(new Text("«Заказчик» ").SetBold());
    secondParagraph.Add("направляет на профессиональное ");
    secondParagraph.Add(new Text("обучение ").SetBold());
    secondParagraph.Add("своего работника по программе «НАЗВАНИЕ ПРОГРАММЫ», стоимость обучения СТОИМОСТЬ рублей за одного человека, согласно заявке.");
    document.Add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    thirdParagraph.Add("1.2. ").SetFirstLineIndent(25);
    thirdParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold());
    thirdParagraph.Add("обязуется провести обучение ");
    thirdParagraph.Add(new Text("«Заказчика» ").SetBold());
    thirdParagraph.Add("по избранной профессии в соответствии с ");
    thirdParagraph.Add(new Text("лицензией № Л035-01276-61/00286753 от 14.05.2015г.").SetBold());
    document.Add(thirdParagraph);

    Paragraph fourthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetPaddingBottom(5.5f);
    fourthParagraph.Add("1.3. Место оказания услуг: г.Волгодонск, ул.Волгодонская, 16.").SetFirstLineIndent(25); 
    document.Add(fourthParagraph);

    Paragraph thirdHeading = new Paragraph().SetTextAlignment(TextAlignment.CENTER).SetMarginTop(0f).SetMarginBottom(0f);
    thirdHeading.Add(new Text("2. Обязательства сторон").SetBold());
    document.Add(thirdHeading);

    Paragraph fifthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    fifthParagraph.Add("2.1. ").SetFirstLineIndent(25); 
    fifthParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold());
    fifthParagraph.Add("принимает на обучение работника или группу работников по избранной программе обучения и гарантирует присвоение квалификации с выдачей свидетельства о профессии рабочего, должности служащего и (или) удостоверения установленного образца, при прохождении дополнительного профессионального образования - удостоверения о повышении квалификации или диплома о профессиональной переподготовке.");
    document.Add(fifthParagraph);

    Paragraph sixthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    sixthParagraph.Add("2.2. ").SetFirstLineIndent(25); 
    sixthParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold());
    sixthParagraph.Add("обязуется провести обучение работников в соответствии с утвержденным учебным планом и программой.");
    document.Add(sixthParagraph);

    Paragraph seventhParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    seventhParagraph.Add("2.3. ").SetFirstLineIndent(25); 
    seventhParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold());
    seventhParagraph.Add("предоставляет ");
    seventhParagraph.Add(new Text("«Заказчику» ").SetBold());
    seventhParagraph.Add("в процессе обучения имеющуюся материально-техническую базу и обеспечивает имеющейся в наличии учебно-методической литературой.");
    document.Add(seventhParagraph);

    Paragraph eighthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    eighthParagraph.Add("2.4. ").SetFirstLineIndent(25); 
    eighthParagraph.Add(new Text("«Заказчик» ").SetBold());
    eighthParagraph.Add("в случае необходимости и при наличии соответствующих возможностей для конкретного вида обучения, професии, предоставляет  ");
    eighthParagraph.Add(new Text("рабочие места (рабочие площадки) ").SetBold());
    eighthParagraph.Add("для прохождения производственного обучения своим работникам, направленным предприятием на обучение в ");
    eighthParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой».").SetBold());
    document.Add(eighthParagraph);

    Paragraph ninthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    ninthParagraph.Add("2.5. ").SetFirstLineIndent(25); 
    ninthParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой»").SetBold());
    ninthParagraph.Add(", на основании настоящего договора, направляет обучающихся для прохождения производственного обучения под руководством мастера производственного обучения или инструктора производственного обучения предприятия");
    ninthParagraph.Add(new Text("«Заказчика».").SetBold());
    document.Add(ninthParagraph);

    Paragraph tenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    tenthParagraph.Add("2.6. ").SetFirstLineIndent(25);
    tenthParagraph.Add("Количество направляемых работников ");
    tenthParagraph.Add(new Text("«Заказчика» ").SetBold());
    tenthParagraph.Add("и сроки производственного обучения оговариваются сторонами дополнительно, оформляются документально, со ссылкой на настоящий договор.");
    document.Add(tenthParagraph);

    Paragraph eleventhParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    eleventhParagraph.Add("2.7. ").SetFirstLineIndent(25);
    eleventhParagraph.Add("Производственное обучение, проходящее на территории ");
    eleventhParagraph.Add(new Text("«Заказчика»").SetBold());
    eleventhParagraph.Add(", обеспечивается методическим и практическим руководством ");
    eleventhParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой»").SetBold());
    eleventhParagraph.Add(", через преподавателя определенной профессии и мастеров производственного обучения ");
    eleventhParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой».").SetBold());
    document.Add(eleventhParagraph);

    Paragraph tvelfthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetPaddingBottom(5.5f);
    tvelfthParagraph.Add("2.8. ").SetFirstLineIndent(25);
    tvelfthParagraph.Add(new Text("«Заказчик» ").SetBold());
    tvelfthParagraph.Add("обязуется создать условия для прохождения производственной практики работникам, продолжительность которой определена программой производственного обучения и выдает заключение о соответствии выполняемой работы избранной профессии.");
    document.Add(tvelfthParagraph);

    Paragraph fourthHeading = new Paragraph().SetTextAlignment(TextAlignment.CENTER).SetMarginTop(0f).SetMarginBottom(0f);
    fourthHeading.Add(new Text("3. Расчеты за обучение").SetBold());
    document.Add(fourthHeading);

    Paragraph thirteenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    thirteenthParagraph.Add("3.1. ").SetFirstLineIndent(25);
    thirteenthParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold());
    thirteenthParagraph.Add("выставляет счет ");
    thirteenthParagraph.Add(new Text("«Заказчику» ").SetBold());
    thirteenthParagraph.Add("согласно заявке на количество обучаемых и необходимую программу обучения.");
    document.Add(thirteenthParagraph);

    Paragraph fourteenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    fourteenthParagraph.Add("3.2. ").SetFirstLineIndent(25);
    fourteenthParagraph.Add(new Text("«Заказчик» ").SetBold());
    fourteenthParagraph.Add("оплачивает счет за обучение, путем перечисления денежных средств на расчетный счет ");
    fourteenthParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold());
    fourteenthParagraph.Add("в течение 20 банковских дней от даты выставления счета. НДС не предусмотрен. Упрощенная система налогообложения (уведомление № 26.2-6 от 26.11.2010г.)");
    document.Add(fourteenthParagraph);

    Paragraph fifteenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    fifteenthParagraph.Add("3.3. Окончание работ за обучение оформляется двухсторонним Актом сдачи-приемки.").SetFirstLineIndent(25);
    document.Add(fifteenthParagraph);

    Paragraph sixteenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetPaddingBottom(5.5f);
    sixteenthParagraph.Add("3.4. Цена договора определена в рублях и составляет ЦЕНА рублей (ПРОПИСЬ) и остается фиксированной на протяжении всего срока выполнения договора, в том числе НДС не предусмотрен, п.2 ст.346.11 НК РФ, УСН(упрощенная система налогообложения).").SetFirstLineIndent(25);
    document.Add(sixteenthParagraph);

    Paragraph fifthHeading = new Paragraph().SetTextAlignment(TextAlignment.CENTER).SetMarginTop(0f).SetMarginBottom(0f);
    fifthHeading.Add(new Text("4. Ответственность сторон").SetBold());
    document.Add(fifthHeading);

    Paragraph seventeenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    seventeenthParagraph.Add("4.1. ").SetFirstLineIndent(25);
    seventeenthParagraph.Add(new Text("ЧОУ ДПО «УЦ «Волгодонскстрой» ").SetBold());
    seventeenthParagraph.Add("несет ответственность за квалификационную подготовку направленных на обучение работников.");
    document.Add(seventeenthParagraph);

    Paragraph eighteenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    eighteenthParagraph.Add("4.2. ").SetFirstLineIndent(25);
    eighteenthParagraph.Add(new Text("«Заказчик» ").SetBold());
    eighteenthParagraph.Add("в случае неисполнения договорных обязательств несет ответственность на основании действующего законодательства.");
    document.Add(eighteenthParagraph);

    Paragraph ninteenthParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetPaddingBottom(5.5f);
    ninteenthParagraph.Add("4.3. ").SetFirstLineIndent(25);
    ninteenthParagraph.Add(new Text("«Исполнитель» ").SetBold());
    ninteenthParagraph.Add("оформляет оказанные услуги по прилагаемым образцам документов: ");
    ninteenthParagraph.Add(new Text("акт выполненных работ. ").SetBold());
    ninteenthParagraph.Add("Указанные документы являются неотъемлемой частью договора.");
    document.Add(ninteenthParagraph);

    Paragraph sixthHeading = new Paragraph().SetTextAlignment(TextAlignment.CENTER).SetMarginTop(0f).SetMarginBottom(0f);
    sixthHeading.Add(new Text("5. Сроки действия договора").SetBold());
    document.Add(sixthHeading);

    Paragraph twentiethParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetPaddingBottom(5.5f);
    twentiethParagraph.Add("5.1. Срок действия договора: ").SetFirstLineIndent(25);
    twentiethParagraph.Add(new Text("с ДАТА НАЧАЛА и действует до полного исполнения Сторонами своих обязательств.").SetBold());
    document.Add(twentiethParagraph);

    Paragraph seventhHeading = new Paragraph().SetTextAlignment(TextAlignment.CENTER).SetMarginTop(0f).SetMarginBottom(0f);
    seventhHeading.Add(new Text("6. Дополнительные условия").SetBold());
    document.Add(seventhHeading);

    Paragraph twentyFirstParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetMarginBottom(0f);
    twentyFirstParagraph.Add("6.1. Возникающие по данному договору разногласия и споры решаются путем переговоров, а при не достижении соглашения рассматриваются согласно законодательству РФ.").SetFirstLineIndent(25);
    document.Add(twentyFirstParagraph);

    Paragraph twentySecondParagraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED).SetMarginTop(0f).SetPaddingBottom(5.5f);
    twentySecondParagraph.Add("6.2. Настоящий договор составлен и подписан в 2-х экземплярах, по одному для каждого из сторон. Все экземпляры договора имеют одинаковую силу.").SetFirstLineIndent(25);
    document.Add(twentySecondParagraph);

    Paragraph eighthHeading = new Paragraph().SetTextAlignment(TextAlignment.CENTER).SetMarginTop(0f).SetMarginBottom(0f);
    eighthHeading.Add(new Text("7. Юридические адреса и реквизиты сторон").SetBold());
    document.Add(eighthHeading);



    Table table = new Table(2).SetTextAlignment(TextAlignment.JUSTIFIED).SetFont(font).SetFontSize(12);

    Paragraph title = new Paragraph("«Исполнитель»");
    Paragraph name = new Paragraph("«ЧОУ ДПО «УЦ «Волгодонскстрой»");
    Paragraph address = new Paragraph("347366 Ростовская область г.Волгодонск, ул.Волгодонская 16");
    Paragraph phoneNumber = new Paragraph("тел. 22-28-23");
    Paragraph title2 = new Paragraph("Платежные реквизиты:");
    Paragraph rs = new Paragraph("р/с 40703810352160100380");
    Paragraph bank = new Paragraph("вЮго-Западный банк ПАО Сбербанк");
    Paragraph city = new Paragraph("г.Ростов-на-Дону");
    Paragraph BIK= new Paragraph("БИК 046015602");
    Paragraph ks = new Paragraph("к/с 30101810600000000602");   
    Paragraph innKpp = new Paragraph("ИНН 6143060182, КПП 614301001");
    Paragraph okpoOkonh = new Paragraph("ОКПО 79211220, ОКОНХ 92200");
    Paragraph OGRN = new Paragraph("ОГРН 1056143066297");

    Paragraph title3 = new Paragraph("«Заказчик»");
    Paragraph organisationName = new Paragraph("Название Организации");
    Paragraph urAddressOrganisation = new Paragraph("Юрид. адрес: ");
    Paragraph factAddressOrganisation = new Paragraph("Факт. адрес: ");
    Paragraph phone = new Paragraph("Т.");
    Paragraph title4 = new Paragraph("Платежные реквизиты:");
    Paragraph rs2 = new Paragraph("р/с ");
    Paragraph ks2 = new Paragraph("к/с ");
    Paragraph BIK2 = new Paragraph("БИК ");
    Paragraph innKpp2 = new Paragraph("ИНН КПП ");
    Paragraph OGRN2 = new Paragraph("ОГРН ");

    Cell column1 = new Cell().Add(title.SetBold()).SetWidth(240);
    column1.Add(name);
    column1.Add(address);
    column1.Add(phoneNumber).SetMarginBottom(50);
    column1.Add(title2.SetBold());
    column1.Add(rs);
    column1.Add(bank);
    column1.Add(city);
    column1.Add(BIK);
    column1.Add(ks);
    column1.Add(innKpp);
    column1.Add(okpoOkonh);
    column1.Add(OGRN);

    table.AddCell(column1);

    Cell column2 = new Cell().Add(title3).SetBold().SetFont(font).SetFontSize(12).SetWidth(240);
    column2.Add(organisationName);
    column2.Add(urAddressOrganisation);
    column2.Add(factAddressOrganisation);
    column2.Add(phone);
    column2.Add(title4);
    column2.Add(rs2);
    column2.Add(ks2);
    column2.Add(BIK2);
    column2.Add(innKpp2);
    column2.Add(OGRN2);

    table.AddCell(column2);

    document.Add(table);

    Table table2 = new Table(2).SetTextAlignment(TextAlignment.JUSTIFIED).SetFont(font).SetFontSize(12).SetPaddingTop(5.5f);

    Cell column3 = new Cell().Add(new Paragraph("Исполнительный директор").SetMarginTop(10).SetMarginBottom(10)).SetBold().SetWidth(240).SetBorder(Border.NO_BORDER);

    column3.Add(new Paragraph("«ЧОУ ДПО «УЦ «Волгодонскстрой»").SetMarginBottom(30));
    column3.Add(new Paragraph("_______________ /Т.В.Валентейчик/"));
    table2.AddCell(column3);

    Cell column4 = new Cell().Add(new Paragraph("Директор").SetMarginTop(10).SetMarginBottom(10)).SetBold().SetWidth(240).SetBorder(Border.NO_BORDER);
    column4.Add(new Paragraph("Краткое название компании").SetMarginBottom(30));
    column4.Add(new Paragraph("_______________ /Инициалы директора/"));
    table2.AddCell(column4);

    document.Add(table2);

    document.Close();
}


