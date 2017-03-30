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

            //model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            //{
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
            //};
        }
    }
}
