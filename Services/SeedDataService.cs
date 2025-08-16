using Portfolio.Data;
using Portfolio.Models;


namespace Portfolio.Services
{
    public class SeedDataService
    {
        private readonly PortfolioDbContext _context;

        public SeedDataService(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task SeedProjectsAsync()
        {
            // Clear existing data if needed
            // _context.Projects.RemoveRange(_context.Projects);

            if (!_context.Projects.Any())
            {
                var projects = new List<Project>
                {
                    // Web Development Projects
                    new Project
                    {
                        Title = "WhatsApp Widget Generator",
                        Category = "Web",
                        Description = "JavaScript WhatsApp Widget Generator. Built with HTML, CSS, and JavaScript.",
                        ImageUrl = "Frontend/img/Projects/Web/whatsappWidget.jpg",
                        ProjectLink = "https://whatsappwidgetgenerator.vercel.app/",
                        CreatedAt = DateTime.UtcNow.AddMonths(-6)
                    },
                    new Project
                    {
                        Title = "JS QR Code Generator",
                        Category = "Web", 
                        Description = "JavaScript QR Code Generator. Built with HTML, CSS, and JavaScript.",
                        ImageUrl = "Frontend/img/Projects/Web/qrcode.jpg",
                        ProjectLink = "https://qrcodegenjs.vercel.app/",
                        CreatedAt = DateTime.UtcNow.AddMonths(-5)
                    },
                    new Project
                    {
                        Title = "Achimota App Landing Page",
                        Category = "Web",
                        Description = "Achimota Centenary App Landing Page. Built with HTML, CSS, and JavaScript.",
                        ImageUrl = "Frontend/img/Projects/Web/oaa.jpg",
                        ProjectLink = "https://oaa-two.vercel.app/",
                        CreatedAt = DateTime.UtcNow.AddMonths(-4)
                    },
                    new Project
                    {
                        Title = "Car Booking (Static)",
                        Category = "Web",
                        Description = "A Car Booking website. Built with HTML, CSS, and JavaScript.",
                        ImageUrl = "Frontend/img/Projects/Web/CarBooking.jpg",
                        ProjectLink = "https://carbooking-phi.vercel.app/",
                        CreatedAt = DateTime.UtcNow.AddMonths(-3)
                    },
                    new Project
                    {
                        Title = "Math Camp",
                        Category = "Web",
                        Description = "A web application to help with Arithmetic. Built with HTML, CSS, and JavaScript.",
                        ImageUrl = "Frontend/img/Projects/Web/mathCamp.jpg",
                        ProjectLink = "https://mathcamp.vercel.app/",
                        CreatedAt = DateTime.UtcNow.AddMonths(-2)
                    },

                    // Graphics Projects
                    new Project
                    {
                        Title = "Green Ghana Day",
                        Category = "Graphics",
                        Description = "Made in Canva.",
                        ImageUrl = "Frontend/img/Projects/Graphics/greenDay.jpg",
                        ProjectLink = "https://www.canva.com/design/DAFlUm0WQxU/ehSD0_MvGr-KvUR6QpPhWQ/edit?utm_content=DAFlUm0WQxU&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton",
                        CreatedAt = DateTime.UtcNow.AddMonths(-1)
                    },
                    new Project
                    {
                        Title = "Volunteer Update",
                        Category = "Graphics",
                        Description = "Made in Canva.",
                        ImageUrl = "Frontend/img/Projects/Graphics/NGO1.jpg",
                        ProjectLink = "https://www.canva.com/design/DAFqkOgVABs/olnLVCcrpni4CBVeRoshdA/edit?utm_content=DAFqkOgVABs&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton",
                        CreatedAt = DateTime.UtcNow.AddDays(-20)
                    },

                    // Video Projects  
                    new Project
                    {
                        Title = "Achimota App Walk through",
                        Category = "Video",
                        Description = "Made in Canva.",
                        ImageUrl = "Frontend/img/Projects/Video/Achimota100.jpg",
                        ProjectLink = "https://www.canva.com/design/DAGsr0cN-Zo/eBkEdWfPnss7kW6_zdVNaQ/edit?utm_content=DAGsr0cN-Zo&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton",
                        CreatedAt = DateTime.UtcNow.AddDays(-10)
                    },
                    new Project
                    {
                        Title = "Road Safety Campaign", 
                        Category = "Video",
                        Description = "Made in Canva.",
                        ImageUrl = "Frontend/img/Projects/Video/roadSafetyCampaign.jpg",
                        ProjectLink = "https://www.canva.com/design/DAFjoVt8uNY/1-euYbwPn5cTemACFSUwKg/edit?utm_content=DAFjoVt8uNY&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton",
                        CreatedAt = DateTime.UtcNow.AddDays(-5)
                    }
                };

                _context.Projects.AddRange(projects);
                await _context.SaveChangesAsync();
            }
        }
    }
}