
document.addEventListener('DOMContentLoaded', function () {
  const params = new URLSearchParams(window.location.search);
  const cidade = params.get('cidade');
  if (!cidade) return;

  const listings = document.querySelectorAll('.listing');
  if (listings.length === 0) return;

  listings.forEach(l => l.classList.remove('highlight'));
  const alvo = document.querySelector('.listing[data-city="' + cidade + '"]');
  if (alvo) {
    alvo.classList.add('highlight');
    setTimeout(() => alvo.scrollIntoView({ behavior: 'smooth', block: 'center' }), 250);
  }
});
