﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace LogApplication.ViewModels {

    public class NamespaceViewModel : INotifyPropertyChanged {

        private bool isChecked;
        public bool IsChecked {
            get { return isChecked; }
            set {
                isChecked = value;
                if (isChecked && Parent != null) {
                    // Bubble up
                    Parent.IsChecked = true;
                }
                if (!isChecked) {
                    // Bubble down
                    foreach (var child in Children) {
                        child.IsChecked = false;
                    }
                }
                OnPropertyChanged("IsChecked");
            }
        }

        private bool isExpanded;
        public bool IsExpanded {
            get {
                return isExpanded;
            }
            set {
                isExpanded = value;
                OnPropertyChanged("IsExpanded");
            }
        }

        private int count;
        public int Count {
            get {
                return count;
            }
            set {
                count = value;
                OnPropertyChanged("Count");
            }
        }
        
        public string Name { get; set; }
        public NamespaceViewModel Parent { get; set; }
        public ObservableCollection<NamespaceViewModel> Children { get; set; }

        public NamespaceViewModel(string name) {
            IsChecked = true;
            IsExpanded = true;
            Name = name;
            Children = new ObservableCollection<NamespaceViewModel>();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}