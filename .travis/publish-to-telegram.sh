#!/bin/bash
bot_token="$1"
chat_id="$2"
document="$3"
message="$4"

curl -F caption="$message" -F name=document -F document=@$document -H "Content-Type:multipart/form-data" "https://api.telegram.org/bot$bot_token/sendDocument?chat_id=$chat_id"