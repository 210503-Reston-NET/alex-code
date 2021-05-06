namespace RRUI
{/// <summary>
 /// Standard Validation Service
 /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// takes in a prompt, keeps asking until given correct input
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        string ValidateString(string prompt);
    }
}