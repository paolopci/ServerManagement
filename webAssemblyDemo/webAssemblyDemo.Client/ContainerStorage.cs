namespace webAssemblyDemo.Client
{
    public class ContainerStorage
    {
        public string _message { get; set; }

        public string GetMessage()
        {
            return _message;
        }

        public void SetMessage(string message)
        {
            _message = message;
        }

    }
}
