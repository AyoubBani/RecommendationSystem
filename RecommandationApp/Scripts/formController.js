document.getElementById('ifCandidate').style = 'display:block';
document.getElementById('ifRepresentant').style = 'display:none';
function choiceVal() {
    if (document.getElementById('is_representant').checked) {

        document.getElementById('ifRepresentant').style = 'display:block';
        document.getElementById('ifCandidate').style = 'display:none';
    } else {
        document.getElementById('ifCandidate').style = 'display:block';
        document.getElementById('ifRepresentant').style = 'display:none';
    }

}