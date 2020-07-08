﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeeklyXamarin.Mobile.Views;
using WeeklyXamarin.Core.ViewModels;
using WeeklyXamarin.Core.Models;
using Container = WeeklyXamarin.Core.Services.Container;
using Microsoft.Extensions.DependencyInjection;

namespace WeeklyXamarin.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    [QueryProperty(nameof(EditionId), nameof(EditionId))]
    public partial class ArticlesListPage : ContentPage
    {
        ArticlesListViewModel viewModel;
        public string EditionId { get; set; }
        public ArticlesListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = Container.Instance.ServiceProvider.GetRequiredService<ArticlesListViewModel>();
        }

        //async void OnItemSelected(object sender, EventArgs args)
        //{
        //    var layout = (BindableObject)sender;
        //    var article = (Article)layout.BindingContext;
        //    await Navigation.PushAsync(new ArticleDetailPage(new ArticleDetailViewModel(article)));
        //}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            viewModel.EditionId = EditionId;
            if (viewModel.Articles.Count == 0)
                await viewModel.LoadArticlesCommand.ExecuteAsync(false);
        }
    }
}