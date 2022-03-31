using System;

namespace pastel_app.exceptions
{
    class ProdutoInexistenteException : Exception {

        public ProdutoInexistenteException(string message) : base(message)
        {
            if (message is null)
                throw new ArgumentNullException(nameof(message));
        }
    }
}