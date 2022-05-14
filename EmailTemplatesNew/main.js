function collapse(value) {
    const content = document.getElementsByClassName("person-details")
    const icon = document.getElementsByClassName("arrow-icon");
    const index = parseInt(value);

    if (content[index].style.display === "grid") {
        content[index].style.display = "none";
        icon[index].setAttribute("name", "chevron-forward-outline")
      } else {
        content[index].style.display = "grid";
        icon[index].setAttribute("name", "chevron-down-outline")
      }
}