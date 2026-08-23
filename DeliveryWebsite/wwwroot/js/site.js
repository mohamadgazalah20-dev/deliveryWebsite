// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<!-- هيدي صفحة الـ HTML عندك -->
<form asp-action="CreateOrder" method="post">
    <!-- حقول الطلب الثانية -->
    
    <div class="mb-3">
        <label>عنوان التوصيل</label>
        <input type="text" id="address" name="Address" class="form-control" />
        <button type="button" class="btn btn-secondary mt-2" onclick="getCustomerLocation()">تحديد موقعي الحالي</button>
    </div>

    <!-- الحقول المخفية للإحداثيات -->
    <input type="hidden" id="latitude" name="Latitude" />
    <input type="hidden" id="longitude" name="Longitude" />

    <button type="submit" class="btn btn-primary">إرسال الطلب</button>
</form>

<!-- هُنا مكان وضع كود الجافاسكريبت -->
<script>
    function getCustomerLocation() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                function(position) {
                    const lat = position.coords.latitude;
                    const lng = position.coords.longitude;

                    // تعبئة الحقول المخفية تلقائياً
                    document.getElementById('latitude').value = lat;
                    document.getElementById('longitude').value = lng;

                    alert("تم تحديد موقعك بنجاح!");
                },
                function(error) {
                    alert("فشل تحديد الموقع. يرجى التأكد من تفعيل الـ GPS والسماح للمتصفح.");
                },
                { enableHighAccuracy: true }
            );
        } else {
            alert("متصفحك لا يدعم تحديد الموقع الجغرافي.");
        }
    }
</script>
