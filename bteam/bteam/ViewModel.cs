using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bteam
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bteam.Model.Model m_model;

        public ViewModel(bteam.Model.Model model)
        {
            m_model = model;

            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
            };
        }

        public double User1
        {
            get { return m_model.User1; }

        }

        public double User2
        {
            get { return m_model.User2; }
        }

        public double User3
        {
            get { return m_model.User3; }
        }

        public double User4
        {
            get { return m_model.User4; }
        }

        public double User5
        {
            get { return m_model.User5; }

        }

        public double User6
        {
            get { return m_model.User6; }
        }

        public double User7
        {
            get { return m_model.User7; }
        }

        public double User8
        {
            get { return m_model.User8; }
        }

        public void start()
        {
            m_model.start();
        }

    }
}
