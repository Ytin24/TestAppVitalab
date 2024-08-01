using System;
using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI;
using TestAppVitalab.Api.DAL.Models;
using TestAppVitalab.Services;

namespace TestAppVitalab.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public ObservableCollection<OrderDTO> OrderCollection { get; set; } = new();
    public string HiUser { get; set; } = "Добро пожаловать";
    public HomeViewModel(IScreen screen, IOrderService orderService, IProductService p) : base(screen)
    {
        screen.Router.CurrentViewModel.Subscribe(async x=>
        {
            if (x != this)
                return;
            OrderCollection.AddRange(await orderService.TryGetOrders());
        });
    }

}