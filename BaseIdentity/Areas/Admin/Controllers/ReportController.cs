using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.EntityLayer.Concrete;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Areas.Admin.Controllers
{
  

    [Area("Admin")]
    // [Authorize(Roles = "Admin")]
    public class ReportController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IEnrollmentDal _enrollmentDal;
        private readonly ICourseService _CourseService;
        Context context = new Context();

        public ReportController(UserManager<AppUser> userManager, IEnrollmentDal enrollmentDal, ICourseService courseService)
        {
            _userManager = userManager;
            _enrollmentDal = enrollmentDal;
            _CourseService = courseService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public List<AppUser> Userlist()
        {
            List<AppUser> ViewModels = new List<AppUser>();
            using (var context = new Context())
            {
                ViewModels = context.Users.Select(x => new AppUser
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    dateOfBirth = x.dateOfBirth,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    City = x.City,
                    University = x.University,
                    Department = x.Department

                }).ToList();
            }
            return ViewModels;
        }

        public IActionResult DynamicExcel()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add(" List");
                workSheet.Cell(1, 1).Value = " Name";
                workSheet.Cell(1, 2).Value = " Surname";
                workSheet.Cell(1, 3).Value = " Date of Birth";
                workSheet.Cell(1, 4).Value = " Phone";
                workSheet.Cell(1, 5).Value = " City";
                workSheet.Cell(1, 6).Value = " University";
                workSheet.Cell(1, 7).Value = " Department";


                int rowCount = 2;
                foreach (var item in Userlist())
                {
                    workSheet.Cell(rowCount, 1).Value = item.Name;
                    workSheet.Cell(rowCount, 2).Value = item.Surname;
                    workSheet.Cell(rowCount, 3).Value = item.dateOfBirth;
                    workSheet.Cell(rowCount, 4).Value = item.PhoneNumber;
                    workSheet.Cell(rowCount, 5).Value = item.City;
                    workSheet.Cell(rowCount, 6).Value = item.University;
                    workSheet.Cell(rowCount, 7).Value = item.Department;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Users-{DateTime.Now}.xlsx");
                }
            }
            return View();
        }


        public async Task<IActionResult> PdfReport(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
           var Enrollments = _enrollmentDal.GetEnrollmentByOwner(user.Id).ToList();

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "user.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            // Add personal information
            Paragraph name = new Paragraph($"{user.Name + " " + user.Surname}");
            name.Alignment = Element.ALIGN_LEFT;
            name.Font = FontFactory.GetFont(FontFactory.HELVETICA, 24, Font.BOLD);
            document.Add(name);

            Paragraph address = new Paragraph($"{user.City}");
            address.Alignment = Element.ALIGN_LEFT;
            address.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
            document.Add(address);

            Paragraph phone = new Paragraph($"{user.PhoneNumber}");
            phone.Alignment = Element.ALIGN_LEFT;
            phone.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
            document.Add(phone);

            Paragraph email = new Paragraph($"{user.Email}");
            email.Alignment = Element.ALIGN_LEFT;
            email.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
            document.Add(email);

            Paragraph website = new Paragraph($"{user.Website}");
            website.Alignment = Element.ALIGN_LEFT;
            website.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
            document.Add(website);

            document.Add(new Paragraph("\n")); //add empty line 

            // Add a section header
            Paragraph summaryHeader = new Paragraph("Summary");
            summaryHeader.Alignment = Element.ALIGN_LEFT;
            summaryHeader.Font.Color = BaseColor.BLUE;
            summaryHeader.Font = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            document.Add(summaryHeader);

            // Add summary text
            Paragraph summary = new Paragraph($"{user.About}");
            document.Add(summary);

            //Add  a photo
            if(user.Image != null)
            {
                string photoPath = "wwwroot/UserImage/" + user.Image;
                Image photo = Image.GetInstance(photoPath);
                photo.ScaleToFit(100f, 150f);
                photo.SetAbsolutePosition(450f, 750f);
                document.Add(photo);
            }

         

            document.Add(new Paragraph("\n")); //add empty line 

            Paragraph experienceHeader = new Paragraph("Courses");
            experienceHeader.Alignment = Element.ALIGN_LEFT;
            experienceHeader.Font.Color = BaseColor.BLUE;
            experienceHeader.Font = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            document.Add(experienceHeader);

            if(Enrollments.Count != 0)
            {
                foreach (var item in Enrollments)
                {
                    // Add job experience
                    Paragraph jobTitle = new Paragraph("Enrollments");
                    jobTitle.Alignment = Element.ALIGN_LEFT;
                    jobTitle.Font.Color = BaseColor.ORANGE;

                    jobTitle.Font = FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD);
                    document.Add(jobTitle);

                    //Paragraph jobDates = new Paragraph("January 2020 - Present");
                    //jobDates.Alignment = Element.ALIGN_LEFT;
                    //jobDates.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
                    //document.Add(jobDates);

                    Paragraph jobDescription = new Paragraph($"{item.Course.Title}");
                    document.Add(jobDescription);

                    document.Add(new Paragraph("\n")); //add empty line 
                }
            }
            if (user.IsLecturer == true)
            {
               
                int idlecturer = int.Parse(id);
             var values=   _CourseService.GetCourseByLecturer(idlecturer);
                Paragraph jobTitle = new Paragraph("As Lecturer:");
                jobTitle.Alignment = Element.ALIGN_LEFT;
                jobTitle.Font.Color = BaseColor.ORANGE;
                jobTitle.Font = FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD);
                document.Add(jobTitle);

                foreach (var item in values)
                {
                    // Add job experience
                  
                    //Paragraph jobDates = new Paragraph("January 2020 - Present");
                    //jobDates.Alignment = Element.ALIGN_LEFT;
                    //jobDates.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
                    //document.Add(jobDates);

                    Paragraph jobDescription = new Paragraph($"{item.Title}");
                    document.Add(jobDescription);

                    document.Add(new Paragraph("\n")); //add empty line 
                }
                
            }

            // Add a section header
            Paragraph educationHeader = new Paragraph("Education");
            educationHeader.Alignment = Element.ALIGN_LEFT;
            educationHeader.Font.Color = BaseColor.BLUE;
            educationHeader.Font = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            document.Add(educationHeader);

            // Add education
            Paragraph degree = new Paragraph($"{user.University}");
            degree.Alignment = Element.ALIGN_LEFT;
            degree.Font = FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD);
            document.Add(degree);

            Paragraph graduationDate = new Paragraph($"{user.Department}");
            graduationDate.Alignment = Element.ALIGN_LEFT;
            graduationDate.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
            document.Add(graduationDate);


            document.Close();

            return File("/PdfReports/user.pdf", "application/pdf", "user.pdf");
        }

    }
}

