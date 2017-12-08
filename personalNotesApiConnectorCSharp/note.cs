using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalNotesApp
{
    public class note
    {
        private string title;
        private string text;
        private int id;
        private String dateCreation;

        public note()
        {
            this.title = "";
            this.text = "";
            this.id = 0;
        }
        public note(int id, string title, string text, string dateCreation)
        {
            this.id = id;
            this.title = title;
            this.text = text;
            this.dateCreation = dateCreation;
        }
        public string getTitle()
        {
            return this.title;
        }
        public string getText()
        {
            return this.text;
        }
        public int getId()
        {
            return this.id;
        }
        public string getDateCreation()
        {
            return this.dateCreation;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }
        public void setText(string text)
        {
            this.text = text;
        }
    }
}
