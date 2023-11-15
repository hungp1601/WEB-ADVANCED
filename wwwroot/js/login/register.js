document.addEventListener("DOMContentLoaded", () => {
  var fullname = document.getElementById("fullname");
  var messFullname = document.getElementById("messFullname");

  var email = document.getElementById("email");
  var messEmail = document.getElementById("messEmail");

  var password = document.getElementById("password");
  var messPassword = document.getElementById("messPassword");

  var rePassword = document.getElementById("confirm-password");
  var messRePassword = document.getElementById("messRePassword");

  var btnRegister = document.getElementById("btnRegister");

  fullname.addEventListener("focusout", () => {
    validFullName(fullname.value, messFullname);
  });
  fullname.addEventListener("keydown", () => {
    hideMess(messFullname);
  });

  email.addEventListener("focusout", () => {
    validEmail(email.value, messEmail);
  });
  email.addEventListener("keydown", () => {
    hideMess(messEmail);
  });

  password.addEventListener("focusout", () => {
    validPassword(password.value, messPassword);
  });
  password.addEventListener("keydown", () => {
    hideMess(messPassword);
  });

  rePassword.addEventListener("focusout", () => {
    validRePassword(password.value, rePassword.value, messRePassword);
  });
  rePassword.addEventListener("keydown", () => {
    hideMess(messRePassword);
  });

  btnRegister.addEventListener("click", function (e) {
    e.preventDefault();

    if (
      !validEmail(email.value, messEmail) ||
      !validPassword(password.value, messPassword) ||
      !validRePassword(password.value, rePassword.value, messRePassword) ||
      !validFullName(fullname.value, messFullname)
    ) {
      return;
    }

    var formData = new FormData();
    formData.append('Email', email.value);
    formData.append('FullName', fullname.value);
    formData.append('Password', password.value);
    formData.append('RePassword', rePassword.value);

    $.ajax({
        type: 'POST',
        url: '/Account/Register',
        contentType: false,
        processData: false,
        cache: false,
        data: formData,
        success: function (response) {
            window.location.href = "/Account/Login";
        },
        error: function (error) {
            alert("Có lỗi xảy ra");
        }
    });
  });
});

const hideMess = (mess) => {
  mess.innerHTML = "";
  mess.style.display = "none";
};

const validEmail = (value, mess) => {
  if (value === "") {
    mess.innerHTML = "Vui lòng nhập email";
    mess.style.display = "block";
    return false;
  }

  return true;
};

const validPassword = (value, mess) => {
  if (value === "") {
    mess.innerHTML = "Vui lòng nhập mật khẩu của bạn";
    mess.style.display = "block";
    return false;
  }

  return true;
};

const validRePassword = (valuePassword, valueRePassword, mess) => {
  if (valueRePassword === "") {
    mess.innerHTML = "Vui lòng nhập lại mật khẩu của bạn";
    mess.style.display = "block";
    return false;
  }

  if (valueRePassword !== valuePassword) {
    mess.innerHTML = "Mật khẩu không khớp";
    mess.style.display = "block";
    return false;
  }

  return true;
};

const validFullName = (value, mess) => {
  if (value === "") {
    mess.innerHTML = "Vui lòng nhập họ và tên của bạn";
    mess.style.display = "block";
    return false;
  }

  return true;
};
