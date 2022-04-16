# API4AI wine recognition sample

TThis directory contains a minimalistic sample that sends requests to the API4AI wine recognition API.
The sample is implemented in  `python` using [aiohttp](https://pypi.org/project/aiohttp/) module.


## Overview

This ready-to-use API provides recognition of labels on wine bottles covering more than 400 000 different labels. The results contain information about the brand of wine and its type.


## Getting started

Preinstall dependencies before use:

```bash
pip3 install -r requirements.txt
```

Try sample with default args:
```bash
python3 sample.py
```

Try sample with your local image:
```bash
python3 sample.py image.jpg
```


## About API keys

This demo by default sends requests to free endpoint at `demo.api4ai.cloud`.
Demo endpoint is rate limited and should not be used in real projects.

To get API key for unlimited access you may buy API at RapidAPI marketplace or
use contact us directly.


## Links

📩 Email: hello@api4.ai
🔗 Website: https://api4.ai
🤖 Telegram demo bot: https://t.me/a4a_img_labelling_bot
🔵 Our API at RapidAPI marketplace: https://rapidapi.com/api4ai-api4ai-default/api/general-classification1/details
