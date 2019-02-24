using System;
using System.ComponentModel;

namespace InnovationAndEntrepreneurship.Models
{
    // TODO WTS: Remove this class once your pages/features are using your data.
    // This is used by the SampleDataService.
    // It is the model class we use to display data on pages like Grid, Chart, and Master Detail.
    public class XM
    {
        public string xmbh { get; set; }
        public string xmmz { get; set; }
        public string xmlb { get; set; }
        public DateTime qssj { get; set; }
        public DateTime jzsj { get; set; }
        public string xmjf { get; set; }
        public string xmjb { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
