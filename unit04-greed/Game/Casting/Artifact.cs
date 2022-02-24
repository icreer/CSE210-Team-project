namespace Unit04.Game.Casting
{
    // TODO: Implement the Artifact class here
    
    // 1) Add the class declaration. Use the following class comment. Make sure you
<<<<<<< HEAD
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
=======
   
>>>>>>> 704c5142eb028f93b9b32c494d56bf1d874a3d5e
    //    inherit from the Actor class.

        /// <summary>
        /// <para>An item of cultural or historical interest.</para>
        /// <para>
        /// The responsibility of an Artifact is to provide a message about itself.
        /// </para>
        /// </summary>
    public class Artifact : Actor
    {
        private string hi;
    // 2) Create the class constructor. Use the following method comment.
        
        /// <summary>
        /// Constructs a new instance of Artifact.
        /// </summary>
       

    // 3) Create the GetMessage() method. Use the following method comment.
        
        /// <summary>
        /// Gets the artifact's message.
        /// </summary>
        /// <returns>The message as a string.</returns>
        public string GetMessage()
        {
            
            return hi;
        }

    // 4) Create the SetMessage(string message) method. Use the following method comment.
        
        /// <summary>
        /// Sets the artifact's message to the given value.
        /// </summary>
        /// <param name="message">The given message.</param>
        public void SetMessage(string message)
        {
            hi = message;
        }
    }
}