document.addEventListener("DOMContentLoaded", function () {
  var email = document.getElementById("email");
  var password = document.getElementById("password");
  var messEmail = document.getElementById("messEmail");
  var messPassword = document.getElementById("messPassword");
  var buttonSubmit = document.getElementById("btn-submit");

  const validEmail = () => {
    if (email.value === "") {
      messEmail.textContent = "Vui lòng nhập email";
      messEmail.style.display = "block";
      return false;
    }

    return true;
  };

  const validPassword = () => {
    if (password.value === "") {
      messPassword.textContent = "Vui lòng nhập mật khẩu";
      messPassword.style.display = "block";
      return false;
    }

    return true;
  };

  email.addEventListener("keydown", function () {
    messEmail.textContent = "";
    messEmail.style.display = "none";
  });
  email.addEventListener("focusout", validEmail);

  password.addEventListener("keydown", function () {
    messPassword.textContent = "";
    messPassword.style.display = "none";
  });
  password.addEventListener("focusout", validPassword);

  buttonSubmit.addEventListener("click", function (e) {
    e.preventDefault();

    if (!validEmail() || !validPassword()) {
      return;
    }

    var formData = new FormData();
    formData.append('email', email.value);
    formData.append('password', password.value);

    $.ajax({
        type: 'POST',
        url: '/Account/Login',
        contentType: false,
        processData: false,
        cache: false,
        data: formData,
        success: function (response) {
            localStorage.setItem("IsLoggin", true);
            localStorage.setItem("Email", response.email);
            window.location.href = "/";
        },
        error: function (error) {
            alert("Có lỗi xảy ra");
        }
    });
  });
});
