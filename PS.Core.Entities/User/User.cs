namespace PS.Core.Entities.User
{
    public class User
	{
        public int ID { get; set; }

        public int UserId { get; set; }
        public string Mobile { set; get; }
        public string Email { set; get; }
        public string CarModel{ get; set; }
        public string LicensNumber { get; set; }
    }
}