namespace NewsApp.MVVM.View;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(Article article)
	{
		InitializeComponent();
		ImageNews.Source = article.Image;
		TitleLbl.Text = article.Title;
		description.Text = article.Description;
		Content.Text = article.Content;
		
	}
}