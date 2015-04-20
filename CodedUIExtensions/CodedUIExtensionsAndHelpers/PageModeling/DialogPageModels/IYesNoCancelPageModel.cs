namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public interface IYesNoCancelPageModel<out TYesModel, out TNoModel, out TCancelModel> : IConfirmDenyPageModel<TYesModel, TNoModel>,
                                                                                            ICancellablePageModel<TCancelModel>,
                                                                                            IPageModel
                                                                                            where TYesModel : IPageModel
                                                                                            where TNoModel : IPageModel
                                                                                            where TCancelModel : IPageModel                                                                                        
    { }
}