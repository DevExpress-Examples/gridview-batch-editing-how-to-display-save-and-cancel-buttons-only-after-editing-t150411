@Code
    ViewData("Title") = "Home Page"
End Code

<script type="text/javascript">
    var isPreviewChangesVisible = false;
    function SetButtonsVisibility(s) {
        var statusBar = s.GetMainElement().getElementsByClassName("StatusBarWithButtons")[0].getElementsByTagName("td")[0];
        if (!s.batchEditApi.HasChanges())
            statusBar.style.visibility = "hidden";
        else
            statusBar.style.visibility = "visible";
    }

    function OnPreviewChangesClick(s, e) {
        if (isPreviewChangesVisible) {
            s.SetText("Show changes");
            GridView.batchEditApi.HideChangesPreview();
        }
        else {
            s.SetText("Hide preview");
            GridView.batchEditApi.ShowChangesPreview();
        }
        isPreviewChangesVisible = !isPreviewChangesVisible;
    }

    function OnCustomButtonClick(s, e) {
        if (e.buttonID == "deleteButton") {
            s.DeleteRow(e.visibleIndex);
            SetButtonsVisibility(s);
        }
    }
    function OnBatchEditEndEditing(s, e) {
        window.setTimeout(function () { SetButtonsVisibility(s); }, 0);
    }
</script>

@Using Html.BeginForm()
    Html.RenderAction("GridViewPartial")
End Using