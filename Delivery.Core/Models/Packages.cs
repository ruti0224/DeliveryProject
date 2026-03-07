namespace Delivery.Core.Models
{
    public class Packages
    {
        public int Id { get; set; }
        public int DeliverID { get; set; }
        public int RecipientID { get; set; }
        public string Description { get; set; }
        public StausP Status { get; set; }

        public Delivers Deliver { get; set; }
<<<<<<< HEAD
        public Recipients recipient { get; set; }
=======
        public Recipients Recipient { get; set; }
>>>>>>> dcb4604375466e6b02a5f82eb243040f91a35087


        
    }
    public enum StausP
    {
        onHold, onWay, Got
    }
}

