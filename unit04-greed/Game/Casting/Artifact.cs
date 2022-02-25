namespace Unit04.Game.Casting
{
    // TODO: Implement the Artifact class here
    
    // 1) Add the class declaration. Use the following class comment. Make sure you

    class Artifact : Actor
    {
        private string text = "";

        class Artifacts
        {

        }

        public string GetMessage()
        {
            return text;
        }

        public void SetMessage(string message)
        {
            text = message;
        }

    }
}