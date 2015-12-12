namespace CaptainPav.Testing.UI.PageModeling.DialogPageModels
{
    public interface IYesNoCancelPageModel<out TYesModel, out TNoModel, out TCancelModel> : IConfirmDenyPageModel<TYesModel, TNoModel>,
                                                                                            ICancellablePageModel<TCancelModel>,
                                                                                            IDialogPageModel
                                                                                            where TYesModel : IPageModel
                                                                                            where TNoModel : IPageModel
                                                                                            where TCancelModel : IPageModel                                                                                        
    { }
}