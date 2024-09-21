// XSS tehlikesi yaratabilecek karakterleri kontrol etme
function checkForXSS(value) {
    // Tehlikeli kabul edilen karakterler veya komutlar
    const xssPatterns = [
        /<script.*?>.*?<\/script>/gi,  // Script tagları
        /<script>.*?<\/script>/gi,  // Script tagları
        /on\w+=".*?"/gi,  // onClick, onError gibi olay işlemleri
        /<.*?>/gi,  // HTML tagları
        /javascript:/gi,  // javascript: protokolü
        /document\.cookie/gi,  // document.cookie erişimi
        /eval\(.+\)/gi,  // eval fonksiyonu
        /<iframe.*?>.*?<\/iframe>/gi  // iframe tagları
    ];

    // Tüm XSS desenlerini kontrol et
    return xssPatterns.some(pattern => pattern.test(value));
}

// Form submit event'i dinleyerek inputları kontrol et
document.querySelector('form').addEventListener('submit', function (event) {
    // form-control ve pl-5 class'larına sahip tüm input alanlarını seç
    let inputs = document.querySelectorAll('input.form-control.pl-5');
    let hasXSS = false;

    // Her input değerini kontrol et
    inputs.forEach(input => {
        const value = input.value;

        if (checkForXSS(value)) {
            hasXSS = true;
            // Uyarı mesajı göster
            alert(`Uyarı: "${input.name}" alanında zararlı kod var.`);
        }
    });

    // Eğer XSS tespit edilirse form gönderimini engelle
    if (hasXSS) {
        event.preventDefault();  // Formun gönderilmesini durdur
    }
});
