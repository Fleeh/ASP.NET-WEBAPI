namespace WebApi_Sql.Models.CaseModels
{
    public class CaseUpdateModel
    {
        public CaseUpdateModel(int id, string status)
        {
            Id = id;
            Status = status;
        }

        public int Id { get; set; }
        public string Status { get; set; }
    }
}