using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Lifecycle.ViewModels
{
    public class AddCommentViewModel : BaseViewModel
    {
        private string _author;
        private string _comment;

        public string Author
        {
            get { return _author; }
            set { SetProperty(ref this._author, value); }
        }

        public string Comment
        {
            get { return _comment; }
            set { SetProperty(ref this._comment, value); }
        }

        public AddCommentViewModel()
        {

        }
    }
}
