

-- Inserção de dados
   select uuid();
   INSERT INTO user (id, 
                     userName, 
                     email, 
                     password, 
                     active)
              VALUES ('d72d6f55-f0f3-11ec-b0d3-00090faa0001',
                     'Denis Fernandes',
                     'fernandes.denisrodrigues@gmail.com',
                     '123456',
                     true),
                     ('d72d6f55-f0f3-11ec-b0d3-00090faa0002',
                     'Denis Fernandes',
                     'fernandes.denisrodrigues@gmail.com',
                     '123456',
                     true);
              
-- Atualização de dados
   UPDATE user set password = '0123' WHERE id = 'd72d6f55-f0f3-11ec-b0d3-00090faa0001';

-- Consulta de dados
   SELECT * FROM user;
   SELECT * FROM user WHERE id = 'd72d6f55-f0f3-11ec-b0d3-00090faa0001';
   
   
-- Exclusão de dados
   DELETE from user WHERE id = 'd72d6f55-f0f3-11ec-b0d3-00090faa0001';
