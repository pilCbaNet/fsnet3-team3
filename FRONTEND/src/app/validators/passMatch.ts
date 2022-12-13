import { FormGroup } from "@angular/forms";

export function passwordMatch(password: any, password2: any) {
    return (formGroup: FormGroup) => {
        const pass = formGroup.controls[password];
        const pass2 = formGroup.controls[password2];

        if(pass2.errors && !pass2.errors['Mustmatch']){
            return;
        }
        if(pass.value !== pass2.value){
            pass2.setErrors({Mustmatch: true})
        } else {
            pass2.setErrors(null);
        }
    }
}