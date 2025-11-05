namespace DeliveryProject.Models
{
    public class Packages
    {
        public int Code { get; set; }
        public int DeliverID { get; set; }
        public int RecipientID { get; set; }
        public string Description { get; set; }
        public StausP Status { get; set; }

    }
    public enum StausP
    {
         onHold,onWay,Got
    }
}

