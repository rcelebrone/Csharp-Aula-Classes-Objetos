using System;

namespace pastel_app.exceptions
{
    class SemDinheiroException : Exception {

        public SemDinheiroException(string message) : base(message)
        {
            if (message is null)
                throw new ArgumentNullException(nameof(message));
        }
    }
}