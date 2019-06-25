function ismaxlength(obj,txt){
var mlength=obj.getAttribute? parseInt(obj.getAttribute("maxlengthS")) : ""
if (obj.getAttribute && obj.value.length>mlength)
obj.value=obj.value.substring(0,mlength)
txt.value = mlength - obj.value.length ;
}
