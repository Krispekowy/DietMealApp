$('.quantity-class').keyup(function () {
    console.log("zero")
    calculate_nutrition($(this).val());
});
function calculate_nutrition(value) {
    console.log("zero");
    //$('#listOfMeals > div').each(function(){
    //     var found = 'false';
    //     $(this).each(function(){
    //          if($(this).text().toLowerCase().indexOf(value.toLowerCase()) >= 0)
    //          {
    //               found = 'true';
    //          }
    //     });
    //     if(found == 'true')
    //     {
    //          $(this).show();
    //     }
    //     else
    //     {
    //          $(this).hide();
    //     }
    //});
}