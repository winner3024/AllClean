H = InputBox("身長（cm）を入力してください。")
W = InputBox("体重（Kg）を入力してください。")
H = H/100
BMI = W/H/H
RS = Round(BMI,1)

End Select
MsgBox "あなたのBMIは "& RS &"です",,"BMI"