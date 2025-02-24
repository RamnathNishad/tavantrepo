using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPCoreMVC.Models
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }  
        public string City {  get; set; }
        public List<SelectListItem> Cities { get; set; }
        public List<string> Languages { get; set; }
    }
}
