

function attachCartEventHandlers(){
    const cartMenu = document.getElementById('cartMenu');
    const openCartButton = document.getElementById('openCartButton');
    const overlay = document.getElementById('overlay');
    const closeCartButton = document.getElementById('closeCartButton');
    console.log("attached !!!!!!");

    openCartButton.addEventListener('click', () => {
        cartMenu.style.display = 'block';
        overlay.style.display = 'block';
    } );

    overlay.addEventListener('click', () => {
        cartMenu.style.display = 'none';
        overlay.style.display = 'none';
    } );

    closeCartButton.addEventListener('click', () => {
        cartMenu.style.display = 'none';
        overlay.style.display = 'none';
    });
    
}