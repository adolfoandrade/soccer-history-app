namespace App.Domain.Models
{
    public class ApiValueReference
    {
        public int Id { get; set; }
        public string TableReference { get; set; }
        public string ApiName { get; set; }
        public int ApiId { get; set; }
        public int AppId { get; set; }
    }
}
