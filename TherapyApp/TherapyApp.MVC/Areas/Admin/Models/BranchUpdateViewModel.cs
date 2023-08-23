namespace TherapyApp.MVC.Areas.Admin.Models
{
    public class BranchUpdateViewModel
    {
        public int Id { get; set; }    
        public string Name { get; set; }
        public string Url { get; set; }

        public bool IsActive { get; set; }
    }
}
