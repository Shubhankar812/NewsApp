using NewsApp.MVVM.Model;
using NewsApp.MVVM.ViewModel;

namespace NewsApp.MVVM.View;

public partial class HomePage : ContentPage
{
    private readonly NewsViewModel _viewModel;
	public HomePage()
	{
		InitializeComponent();
        _viewModel = new NewsViewModel();
        

        CategoryView.BindingContext = new CategoryViewModel();
		
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

		CallAPI("general");
	
    }

    private async void CallAPI(string v)
    {
        // Show loading indicator
        LoadingIndicator.IsRunning = true;
        LoadingIndicator.IsVisible = true;

        CategoryView.IsVisible = false;
        ArticleList1.IsVisible= false;

        // Fetch data using a background thread
        List<Article> articles = await Task.Run(async () =>
        {
            return await _viewModel.LoadNews(v);
        });

        // Dispatch UI update to main thread
        Device.BeginInvokeOnMainThread(() =>
        {
            
            ArticleList1.ItemsSource = articles;

            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;

            CategoryView.IsVisible = true;
            ArticleList1.IsVisible = true;
        });
    }




    private void CategoryView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = (e.CurrentSelection.FirstOrDefault() as Category)?.Name;
        if (!string.IsNullOrEmpty(selectedItem))
        {
            CallAPI(selectedItem); // Pass the selected category name to CallAPI method
        }
    }

    private void ArticleList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = (e.CurrentSelection.FirstOrDefault()) as Article;
        if(selectedItem != null)
        {
            Navigation.PushAsync(new DetailsPage(selectedItem));
        }
    }
}