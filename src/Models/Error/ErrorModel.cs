using System.Collections.Generic;

namespace FollowersPark.Models.Error
{
    public class ErrorModel
    {
        public ErrorModel(string message)
        {
            Message = message;
        }

        public ErrorModel(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}