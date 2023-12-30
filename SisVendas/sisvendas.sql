-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 15-Jan-2022 às 02:20
-- Versão do servidor: 10.4.21-MariaDB
-- versão do PHP: 7.3.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `sisvendas`
--
CREATE DATABASE IF NOT EXISTS `sisvendas` DEFAULT CHARACTER SET utf8 COLLATE utf8_swedish_ci;
USE `sisvendas`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_clientes`
--

CREATE TABLE `tab_clientes` (
  `id_cliente` int(10) NOT NULL,
  `nome` varchar(50) COLLATE utf8_swedish_ci NOT NULL,
  `email` varchar(50) COLLATE utf8_swedish_ci NOT NULL,
  `fone` varchar(15) COLLATE utf8_swedish_ci NOT NULL,
  `dtnasc` date NOT NULL,
  `sexo` varchar(10) COLLATE utf8_swedish_ci NOT NULL,
  `ativo` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

--
-- Extraindo dados da tabela `tab_clientes`
--

INSERT INTO `tab_clientes` (`id_cliente`, `nome`, `email`, `fone`, `dtnasc`, `sexo`, `ativo`) VALUES
(1, 'Tereza Aparecida', 'tereza@gmail.com', '11911111111', '2011-02-16', 'Feminino', 1),
(3, 'João da Silva Pereira', 'joao@gmail.com', '11922222222', '2003-05-20', 'Masculino', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_itens_pedido`
--

CREATE TABLE `tab_itens_pedido` (
  `id_item` int(10) NOT NULL,
  `id_pedido` int(10) NOT NULL,
  `id_produto` int(10) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `qtde` int(10) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

--
-- Extraindo dados da tabela `tab_itens_pedido`
--

INSERT INTO `tab_itens_pedido` (`id_item`, `id_pedido`, `id_produto`, `valor`, `qtde`, `subtotal`) VALUES
(13, 6, 2, '28.00', 2, '56.00'),
(14, 6, 8, '4654.05', 1, '4654.05'),
(15, 7, 4, '143.56', 1, '143.56'),
(16, 7, 9, '480.10', 1, '480.10'),
(17, 7, 3, '145.20', 1, '145.20'),
(18, 7, 5, '9200.40', 1, '9200.40'),
(19, 7, 2, '28.00', 2, '56.00'),
(20, 7, 8, '4654.05', 1, '4654.05'),
(21, 7, 1, '35.00', 1, '35.00'),
(22, 8, 4, '143.56', 1, '143.56'),
(23, 8, 5, '9200.40', 2, '18400.80'),
(24, 9, 5, '9200.40', 1, '9200.40'),
(25, 9, 8, '4654.05', 1, '4654.05'),
(26, 10, 5, '9200.40', 1, '9200.40'),
(27, 10, 8, '4654.05', 1, '4654.05'),
(28, 10, 1, '35.00', 2, '70.00'),
(29, 11, 5, '9200.40', 1, '9200.40'),
(30, 11, 8, '4654.05', 1, '4654.05'),
(31, 11, 2, '28.00', 1, '28.00'),
(33, 13, 8, '4654.05', 1, '4654.05'),
(34, 13, 1, '35.00', 1, '35.00'),
(35, 14, 4, '143.56', 2, '287.12'),
(36, 14, 9, '480.10', 1, '480.10'),
(37, 14, 8, '4654.05', 1, '4654.05'),
(38, 15, 5, '9200.40', 1, '9200.40'),
(39, 16, 3, '145.20', 1, '145.20'),
(40, 16, 2, '28.00', 2, '56.00'),
(41, 16, 1, '35.00', 1, '35.00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_pedidos`
--

CREATE TABLE `tab_pedidos` (
  `id_pedido` int(10) NOT NULL,
  `id_cliente` int(10) NOT NULL,
  `id_usuario` int(10) NOT NULL,
  `data` date NOT NULL,
  `total` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

--
-- Extraindo dados da tabela `tab_pedidos`
--

INSERT INTO `tab_pedidos` (`id_pedido`, `id_cliente`, `id_usuario`, `data`, `total`) VALUES
(6, 1, 1, '2022-01-13', '4710.05'),
(7, 3, 1, '2022-01-13', '14714.31'),
(8, 1, 1, '2022-01-14', '18544.36'),
(9, 3, 1, '2022-01-14', '13854.45'),
(10, 1, 1, '2022-01-14', '13924.45'),
(11, 1, 1, '2022-01-14', '13882.45'),
(13, 1, 1, '2022-01-14', '4689.05'),
(14, 3, 1, '2022-01-14', '5421.27'),
(15, 1, 1, '2022-01-14', '9200.40'),
(16, 3, 1, '2022-01-14', '236.20');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_produtos`
--

CREATE TABLE `tab_produtos` (
  `id_produto` int(11) NOT NULL,
  `nome` varchar(100) COLLATE utf8_swedish_ci NOT NULL,
  `foto` varchar(30) COLLATE utf8_swedish_ci NOT NULL,
  `descricao` mediumtext COLLATE utf8_swedish_ci NOT NULL,
  `qtde` int(10) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `ativo` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

--
-- Extraindo dados da tabela `tab_produtos`
--

INSERT INTO `tab_produtos` (`id_produto`, `nome`, `foto`, `descricao`, `qtde`, `valor`, `ativo`) VALUES
(1, 'Teclado Gamer Dragon Vinik', 'teclado.jpg', 'O teclado Dragon da Vinik traz um design simples e recursos interessantes para o público gamer iniciante. O acessório conta com 126 teclas macias e de rápida resposta com letras gravadas a laser. Além disso, as teclas multimídia permitem controlar a reprodução de músicas sem minimizar ou abrir janelas.', 10, '35.00', 1),
(2, 'Mouse para jogos RGB level 20', 'mouse.jpg', 'O Level 20 RGB é um mouse para jogos de alto desempenho equipado com um poderoso sensor óptico de jogos de 16.000 DPI e comutadores OMRON duráveis ​​com capacidade de até 50 milhões de cliques para infinitas horas de jogo.', 10, '28.00', 1),
(3, 'Headphone Bluetooth FUN com Entrada MicroSD', 'headphone.jpg', 'Leve suas músicas sempre com você com praticidade e segurança! O Headphone GT Fun dá um show de versatilidade: além da função bluetooth, possui entrada para cartão de memória e também conexão P2! Experimente toda a liberdade de usar seu fone sem precisar estar sempre conectado ao celular, garantindo maior segurança e economia da bateria do seu aparelho!', 10, '145.20', 1),
(4, 'Câmera IP Wifi 720P Robo C/ Áudio Grava CartãoSD', 'camera-seguranca.jpg', 'Câmera IP Imagem Em Alta resolução Full HD 720p P2P Visão Noturna Wireless Protocolo Onvif 2.4\r\n\r\nGarantimos 100% De Satisfação\r\nEnviamos Video Tutorial, Passo a Passa e Suporte Por WhatsApp\r\nPode ser usada Também em Qualquer Nvr inclusive Intelbras\r\nEnvio de alarme para celular por sensor de movimento\r\n\r\nNova Versão maior alcance e rapidez na transmissão Wifi e Movimento Agora com duas antenas\r\n(não trava como as demais)', 10, '143.56', 1),
(5, 'iPhone 13 Pro Max Apple (128GB) Grafite, Tela de 6', 'iphone.jpg', 'iPhone 13 Pro Max. O maior upgrade do sistema de câmera Pro até hoje. Tela Super Retina XDR com ProMotion para uma experiência mais rápida e responsiva. Chip A15 Bionic com velocidade impressionante. 5G ultrarrápido*. Design resistente. E a maior duração de bateria em um iPhone**. ', 10, '9200.40', 1),
(8, 'Projetor Epson PowerLite E10+ XGA 1024x768p', 'projetor.jpg', 'O projetor PowerLite E10+ é o projetor ideal para o seu negócio. Oferece uma tela de mais de 300\" com qualidade excepcional. A tecnologia 3LCD oferece imagens claras, brilhantes e repletas de cor. Seu brilho de 3.600 lumens em cores e 3.600 lumens em branco o torna a melhor escolha. Sua resolução XGA de 1.024x768 pixels é ideal para apresentações. Seu design compacto e portátil o torna a melhor escolha para os executivos modernos. Ele ainda tem as conexões 1 HDMI 1, USB e 1 VGA e tem disponibilidade na cor branca.', 10, '4654.05', 1),
(9, 'Echo Dot (4ª geração): Smart Speaker com Relógio e', 'sem-imagem.jpg', 'Complete qualquer ambiente com a Alexa. Nosso smart speaker de maior sucesso tem um design elegante e compacto que se encaixa perfeitamente em espaços pequenos. O novo design de áudio direcional (1 speaker de 1,6”) garante mais graves e um som completo. Ele oferece vocais nítidos e graves equilibrados para você aproveitar em qualquer lugar de sua casa.', 10, '480.10', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_usuarios`
--

CREATE TABLE `tab_usuarios` (
  `id_usuario` int(10) NOT NULL,
  `nome` varchar(50) COLLATE utf8_swedish_ci NOT NULL,
  `email` varchar(50) COLLATE utf8_swedish_ci NOT NULL,
  `login` varchar(20) COLLATE utf8_swedish_ci NOT NULL,
  `senha` varchar(100) COLLATE utf8_swedish_ci NOT NULL,
  `frase` varchar(100) COLLATE utf8_swedish_ci NOT NULL,
  `nivel` int(1) NOT NULL,
  `ativo` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

--
-- Extraindo dados da tabela `tab_usuarios`
--

INSERT INTO `tab_usuarios` (`id_usuario`, `nome`, `email`, `login`, `senha`, `frase`, `nivel`, `ativo`) VALUES
(1, 'Fábio Corrêa', 'shefarol@hotmail.com', 'admin', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'padrão', 0, 1),
(2, 'Maria Aparecida Carsoso de Almeida', 'maria@gmail.com', 'maria', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'padrão', 1, 1);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `tab_clientes`
--
ALTER TABLE `tab_clientes`
  ADD PRIMARY KEY (`id_cliente`);

--
-- Índices para tabela `tab_itens_pedido`
--
ALTER TABLE `tab_itens_pedido`
  ADD PRIMARY KEY (`id_item`),
  ADD KEY `id_pedido` (`id_pedido`),
  ADD KEY `id_produto` (`id_produto`);

--
-- Índices para tabela `tab_pedidos`
--
ALTER TABLE `tab_pedidos`
  ADD PRIMARY KEY (`id_pedido`),
  ADD KEY `id_cliente` (`id_cliente`),
  ADD KEY `id_usuario` (`id_usuario`);

--
-- Índices para tabela `tab_produtos`
--
ALTER TABLE `tab_produtos`
  ADD PRIMARY KEY (`id_produto`);

--
-- Índices para tabela `tab_usuarios`
--
ALTER TABLE `tab_usuarios`
  ADD PRIMARY KEY (`id_usuario`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `tab_clientes`
--
ALTER TABLE `tab_clientes`
  MODIFY `id_cliente` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `tab_itens_pedido`
--
ALTER TABLE `tab_itens_pedido`
  MODIFY `id_item` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=42;

--
-- AUTO_INCREMENT de tabela `tab_pedidos`
--
ALTER TABLE `tab_pedidos`
  MODIFY `id_pedido` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT de tabela `tab_produtos`
--
ALTER TABLE `tab_produtos`
  MODIFY `id_produto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de tabela `tab_usuarios`
--
ALTER TABLE `tab_usuarios`
  MODIFY `id_usuario` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `tab_itens_pedido`
--
ALTER TABLE `tab_itens_pedido`
  ADD CONSTRAINT `tab_itens_pedido_ibfk_1` FOREIGN KEY (`id_pedido`) REFERENCES `tab_pedidos` (`id_pedido`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `tab_itens_pedido_ibfk_2` FOREIGN KEY (`id_produto`) REFERENCES `tab_produtos` (`id_produto`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tab_pedidos`
--
ALTER TABLE `tab_pedidos`
  ADD CONSTRAINT `tab_pedidos_ibfk_1` FOREIGN KEY (`id_cliente`) REFERENCES `tab_clientes` (`id_cliente`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `tab_pedidos_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `tab_usuarios` (`id_usuario`) ON DELETE NO ACTION ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
