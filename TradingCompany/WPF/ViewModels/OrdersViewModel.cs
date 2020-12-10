using BusinessLogic.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.Commands;
using WPF.Models;
using WPF.Windows;
using Unity;
using Unity.Resolution;

namespace WPF.ViewModels
{
    public class OrdersViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private ApplicationUser _user;
        private readonly OrderManager _orderManager;
        private ObservableCollection<OrderDTO> _orderList;
        public CollectionViewSource MyView { get; set; }
        private string _filterText;
        public string FilterText { 
            get { 
                return _filterText;
            } 
            set {
                _filterText = value;
                OnPropertyChanged(nameof(FilterText));
            } }

        public ObservableCollection<OrderDTO> OrderList
        {
            get { return _orderList; }
            set
            {
                
                _orderList = value;
                OnPropertyChanged(nameof(OrderList));
            }
        }

        public OrdersViewModel(OrderManager orderManager, ApplicationUser user)
        {
            FilterText = "";
            this._orderManager = orderManager;
            this._user = user;
            UpdateDataCommand = new RelayCommand(UpdateData, p => true);
            ElementDoubleClickCommand = new RelayCommand(ElementDoubleClick, p => true);
            UpdateDataCommand.Execute(null);
   
        }
        public void UpdateData(object obj = null)
        {
            this.OrderList = new ObservableCollection<OrderDTO>(this._orderManager.GetAllOrdersByUserId(_user.UserId));
        }
        public void TextFilter(object obj, FilterEventArgs e)
        {
            var order = e.Item as OrderDTO;
            if(FilterText == null || order == null)
            {
                return;
            }
            if (order.Ordernumber.Contains(FilterText) || order.Comment.Contains(FilterText))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }

        }
        public void TextChanged(object obj,TextChangedEventArgs e)
        {
            _filterText = (obj as TextBox).Text;
            MyView.View.Refresh();
        }
        public void ElementDoubleClick(object obj)
        {
            var element = obj as OrderDTO;
            OrderDetails orderDetails = WPF.App.Container.Resolve<OrderDetails>(new ResolverOverride[] { new ParameterOverride("order", element)});
            orderDetails.Show();

        }
        public RelayCommand UpdateDataCommand { get; private set; }
        public RelayCommand ElementDoubleClickCommand { get; private set; }
        public object Resources { get; private set; }
    }
}
