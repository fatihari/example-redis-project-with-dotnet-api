1- docker-compose.yaml dosyasını çalıştırmak, ve durdurduktan tekrar sonra çalıştırmak için aşağıdaki kod çalıştırılır.
1- docker compose up -d

2- docker containeri durdurur.
2- docker compose stop


3- docker containeri siler.
3- docker compose down

4- Redis ayağa kalktıktan sonra redis-cli'yi açmak ping yollamak için
4- docker exec -it containerId sh
4- redis-cli
4- ping
4- scan 0 (tüm verileri print eder) ONEMLİ!!!
4- exit (double)
