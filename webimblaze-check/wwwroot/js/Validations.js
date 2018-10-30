function IsRecipeNameEmpty() {
    if (document.getElementById('TxtRecipeName').value === "") {
        return 'Recipe Name should not be empty';
    }
    else { return ""; }
}

function IsRecipeNameInvalid() {
    if (document.getElementById('TxtRecipeName').value.indexOf("@") !== -1) {
        return 'Recipe Name really should not contain @';
    }
    else { return ""; }
}
function IsCuisineInvalid() {
    if (document.getElementById('TxtCuisine').value.length >= 10) {
        return 'Cuisine should not contain more than 10 characters';
    }
    else { return ""; }
}
function IsMaxPrepTimeEmpty() {
    if (document.getElementById('TxtMaxPrepTime').value === "") {
        return 'Max Prepartion Time should not be empty';
    }
    else { return ""; }
}
function IsMaxPrepTimeInvalid() {
    if (isNaN(document.getElementById('TxtMaxPrepTime').value)) {
        return 'Enter valid max prepartion time';
    }
    else { return ""; }
}
function IsValid() {

    var RecipeNameEmptyMessage = IsRecipeNameEmpty();
    var RecipeNameInvalidMessage = IsRecipeNameInvalid();
    var CuisineInvalidMessage = IsCuisineInvalid();
    var MaxPrepTimeEmptyMessage = IsMaxPrepTimeEmpty();
    var MaxPrepTimeInvalidMessage = IsMaxPrepTimeInvalid();

    var FinalErrorMessage = "Errors:";
    if (RecipeNameEmptyMessage !== "")
        FinalErrorMessage += "\n" + RecipeNameEmptyMessage;
    if (RecipeNameInvalidMessage !== "")
        FinalErrorMessage += "\n" + RecipeNameInvalidMessage;
    if (CuisineInvalidMessage !== "")
        FinalErrorMessage += "\n" + CuisineInvalidMessage;
    if (MaxPrepTimeEmptyMessage !== "")
        FinalErrorMessage += "\n" + MaxPrepTimeEmptyMessage;
    if (MaxPrepTimeInvalidMessage !== "")
        FinalErrorMessage += "\n" + MaxPrepTimeInvalidMessage;

    if (FinalErrorMessage !== "Errors:") {
        //alert(FinalErrorMessage);
        return false;
    }
    else {
        return true;
    }
}