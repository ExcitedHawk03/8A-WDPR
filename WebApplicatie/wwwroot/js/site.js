var createRoomBtn = document.getElementById('Create_Room+')
var createRoomModal = document.getElementById('room_modal')

createRoomBtn.addEventListener('click', function () {
    createRoomModal.classList.add('active')
})

function closeModal() {
    createRoomModal.classList.remove('active')
}