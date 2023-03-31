using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pz10_4
{
    public partial class MainWindow : Window
    {
        List<Notes> notes;
        List<Notes> activeNotes;
        List<Notes> completeNotes;
        public MainWindow()
        {
            InitializeComponent();
            notes = new List<Notes>() {
            new Notes("погладить кошетчек",Status.Active),
            new Notes("помяукать",Status.Active),
             new Notes("получить неаттестацию по мдк",Status.Completed)
            };
            Update();
        }

        private void Online_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Online.SelectedItem == null) return;
            var a = notes.FindIndex(u => u == Online.SelectedItem);
            notes[a].status = Status.Completed;
            Update();
        }
        public void Update()
        {
            activeNotes = notes.Where(u => u.status == Status.Active).ToList();
            completeNotes = notes.Where(u => u.status == Status.Completed).ToList();
            Online.ItemsSource = activeNotes;
            Offline.ItemsSource = completeNotes;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (TextNotes.Text == "" || TextNotes.Text == null) return;
            notes.Add(new Notes(TextNotes.Text, Status.Active));
            Update();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Offline.SelectedItems == null) return;
            foreach (var note in Offline.SelectedItems)
            {
                notes.Remove((Notes)note);
            }
            Update();
        }
    }
}
