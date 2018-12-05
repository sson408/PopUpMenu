function Search() {
    var input, filter, table, tr, td, i;
    input = document.getElementById("MySearch");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                //show
                tr[i].style.display = "";
            } else {
                //hide
                tr[i].style.display = "none";
            }
        }
    }

}
