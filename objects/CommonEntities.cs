namespace RegistrationAPI.objects
{
    public class CommonEntities
    {

    }
    public class ResponseEntity
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        //   public string MessageCode { get; set; }
        public ResponseEntity()
        {

        }
        public ResponseEntity(int status, string msg, object data)
        {
            this.Status = status;
            this.Message = msg;
            this.Data = data;
        }
    }
}
