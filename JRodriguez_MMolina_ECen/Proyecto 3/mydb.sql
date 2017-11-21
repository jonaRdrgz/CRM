-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: db
-- Generation Time: Nov 06, 2017 at 01:18 AM
-- Server version: 10.2.9-MariaDB-10.2.9+maria~jessie
-- PHP Version: 7.0.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mydb`
--
CREATE DATABASE IF NOT EXISTS `mydb` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `mydb`;

DELIMITER $$
--
-- Procedures
--
DROP PROCEDURE IF EXISTS `getContactoEmpresa`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getContactoEmpresa` (IN `pIdUsuario` INT(11))  BEGIN
select empresa.idEmpresa, empresa.descripcionEmpresa, telefono.descripcionTelefono, direccion.descripcionDireccion, idEntidad

from entidad

inner join empresa on entidad.idEntidad = empresa.idEntidadEmpresa
inner join telefono on entidad.idEntidad = telefono.idEntidadTelefono
inner join direccion on entidad.idEntidad = direccion.idEntidadDireccion

where entidad.idUsuarioEntidad = pIdUsuario

ORDER BY empresa.descripcionEmpresa ASC;

END$$

DROP PROCEDURE IF EXISTS `getContactoPersona`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getContactoPersona` (IN `pIdUsuario` INT(11))  BEGIN
select persona.idPersona, persona.nombrePersona, persona.apellido1Persona, persona.apellido2Persona, persona.descripcionEmpresaPersona, telefono.descripcionTelefono, direccion.descripcionDireccion, correo.descripcionCorreo, persona.idEntidadPersona

from entidad

inner join persona on entidad.idEntidad = persona.idEntidadPersona
inner join telefono on entidad.idEntidad = telefono.idEntidadTelefono
inner join direccion on entidad.idEntidad = direccion.idEntidadDireccion
inner join correo on correo.idPersonaCorreo = persona.idPersona


where entidad.idUsuarioEntidad = pIdUsuario

ORDER BY persona.nombrePersona ASC;
END$$

DROP PROCEDURE IF EXISTS `getEntidadUsuario`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getEntidadUsuario` (IN `pIdUsuario` INT(11))  BEGIN
select idEntidad
from entidad
where idUsuarioEntidad = pIdUsuario order by idEntidad desc;
END$$

DROP PROCEDURE IF EXISTS `getIdUsuario`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getIdUsuario` (IN `pDescripciónUsuario` VARCHAR(45), IN `pUsuarioContrasena` VARCHAR(45))  BEGIN
select idUsuario
from usuario
where descripcionUsuario = pDescripcionUsuario and contrasenaUsuario = pUsuarioContrasena;
END$$

DROP PROCEDURE IF EXISTS `getPersona`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getPersona` (IN `pIdEntidad` INT(11))  BEGIN
select idPersona 
from persona
where idEntidadPersona = pIdEntidad;
END$$

DROP PROCEDURE IF EXISTS `getProductos`$$
CREATE DEFINER=`root`@`%` PROCEDURE `getProductos` ()  NO SQL
BEGIN
SELECT producto.idProducto, producto.nombre FROM producto;
END$$

DROP PROCEDURE IF EXISTS `getPropuestaVenta`$$
CREATE DEFINER=`root`@`%` PROCEDURE `getPropuestaVenta` (IN `pIdUsuario` INT)  NO SQL
BEGIN
select producto.nombre, propuestaventa.precio, date(propuestaventa.fechaPropuestaVenta), propuestaventa.idPropuestaVenta, respuestadepropuesta.estado

from propuestaventa

inner join producto on propuestaventa.productoPropuestaVenta = producto.idProducto

inner join respuestadepropuesta on propuestaventa.idPropuestaVenta = respuestadepropuesta.idPropuestaVenta

where propuestaventa.idVendedor = pIdUsuario;
END$$

DROP PROCEDURE IF EXISTS `getPropuestaVentaXContacto`$$
CREATE DEFINER=`root`@`%` PROCEDURE `getPropuestaVentaXContacto` (IN `pIdUsuario` INT, IN `pIdContacto` INT)  NO SQL
SELECT producto.nombre, propuestaventa.precio, date(propuestaventa.fechaPropuestaVenta),
respuestadepropuesta.estado

FROM propuestaventa

inner join producto on propuestaventa.productoPropuestaVenta = producto.idProducto
inner join respuestadepropuesta on propuestaventa.idPropuestaVenta = respuestadepropuesta.idPropuestaVenta

where propuestaventa.idVendedor = pIdUsuario 
	and propuestaventa.idContacto = pIdContacto$$

DROP PROCEDURE IF EXISTS `getUsuario`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getUsuario` (`pDescripcionUsuario` VARCHAR(45))  BEGIN
select idUsuario
from usuario
where descripcionUsuario = pDescripcionUsuario;
END$$

DROP PROCEDURE IF EXISTS `getVentas`$$
CREATE DEFINER=`root`@`%` PROCEDURE `getVentas` (IN `pIdUsuario` INT(11))  NO SQL
BEGIN
select producto.nombre, venta.descuento, venta.porcentajeComision,
		date(venta.fecha), venta.precioFinal, venta.comision

from venta

inner join producto on venta.idProducto = producto.idProducto

where venta.idVendedor = pIdUsuario;
END$$

DROP PROCEDURE IF EXISTS `getVentaXContacto`$$
CREATE DEFINER=`root`@`%` PROCEDURE `getVentaXContacto` (IN `pIdUsuario` INT, IN `pIdContacto` INT)  NO SQL
BEGIN
select producto.nombre,date(venta.fecha), venta.precioFinal

from venta

inner join producto on venta.idProducto = producto.idProducto

where venta.idVendedor = pIdUsuario and venta.idContacto = pIdContacto;
END$$

DROP PROCEDURE IF EXISTS `insertCorreo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertCorreo` (`pDescripcionCorreo` VARCHAR(45), `pIdPersona` INT(11))  BEGIN
	insert into correo(idCorreo, descripcionCorreo, idPersonaCorreo)
    values (null, pDescripcionCorreo, pIdPersona);
END$$

DROP PROCEDURE IF EXISTS `insertDireccion`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertDireccion` (IN `pDescripcionDireccion` VARCHAR(45), IN `pIdEntidad` INT(11))  BEGIN
insert into direccion(idDireccion, descripcionDireccion, idEntidadDireccion)
values (null, pDescripcionDireccion, pIdEntidad);

END$$

DROP PROCEDURE IF EXISTS `insertEmpresa`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertEmpresa` (IN `pDescripcionEmpresa` VARCHAR(45), IN `pTelefonoEmpresa` VARCHAR(45), IN `pDireccionEmpresa` VARCHAR(45), IN `pIdUsuario` INT(11))  BEGIN

set @IDEntidad = insertEntidad(pIdUsuario);

insert into empresa(idEmpresa, descripcionEmpresa, idEntidadEmpresa)
values(null, pDescripcionEmpresa, @IDEntidad);

call insertTelefono(pTelefonoEmpresa, @IDEntidad);
call insertDireccion(pDireccionEmpresa, @IDEntidad);

commit;

END$$

DROP PROCEDURE IF EXISTS `insertPersona`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertPersona` (IN `pNombrePersona` VARCHAR(45), IN `pApellido1Persona` VARCHAR(45), IN `pApellido2Persona` VARCHAR(45), IN `pTelefonoPersona` VARCHAR(45), IN `pDireccionPersona` VARCHAR(45), IN `pDescripcionEmpresaPersona` VARCHAR(45), IN `pIdUsuario` INT(11), IN `pCorreoPersona` VARCHAR(45))  BEGIN
set @IDEntidad = insertEntidad(pIdUsuario);

insert into persona(idPersona, nombrePersona, apellido1Persona, apellido2Persona, descripcionEmpresaPersona, idEntidadPersona)
values(null, pNombrePersona, pApellido1Persona, pApellido2Persona, pDescripcionEmpresaPersona, @IDEntidad);

set @IDPersona = LAST_INSERT_ID();

call insertTelefono(pTelefonoPersona, @IDEntidad);
call insertDireccion(pDireccionPersona, @IDEntidad);
call insertCorreo(pCorreoPersona, @IDPersona);

commit;

END$$

DROP PROCEDURE IF EXISTS `insertPropuestaVenta`$$
CREATE DEFINER=`root`@`%` PROCEDURE `insertPropuestaVenta` (IN `pIdProducto` INT(11), IN `pfecha` DATE, IN `pPrecio` INT(11), IN `pIdVendedor` INT(11), IN `pIdContacto` INT(11))  NO SQL
BEGIN
INSERT INTO propuestaventa (idPropuestaVenta, productoPropuestaVenta, fechaPropuestaVenta, precio, idVendedor, idContacto)
VALUES (null, pIdProducto, pFecha, pPrecio, pIdVendedor, pIdContacto);

INSERT INTO respuestadepropuesta (idRespuestaDePropuesta, idPropuestaVenta, fecha)
VALUES (null, LAST_INSERT_ID(), pfecha);


COMMIT;
END$$

DROP PROCEDURE IF EXISTS `insertTelefono`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertTelefono` (IN `pDescripcionTelefono` VARCHAR(45), IN `pIdEntidad` INT(11))  BEGIN
insert into telefono(idTelefono, descripcionTelefono, idEntidadTelefono)
values (null, pDescripcionTelefono, pIdEntidad);

END$$

DROP PROCEDURE IF EXISTS `insertUsuario`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insertUsuario` (IN `pDescripcionUsuario` VARCHAR(45), IN `pContrasena` VARCHAR(45))  BEGIN
insert into usuario(idUsuario, descripcionUsuario, contrasenaUsuario)
value (null, pDescripcionUsuario, pContrasena);
commit;
END$$

DROP PROCEDURE IF EXISTS `insertVenta`$$
CREATE DEFINER=`root`@`%` PROCEDURE `insertVenta` (IN `pIdProducto` INT(11), IN `pDescuento` INT(11), IN `pPorcentajeComision` INT(11), IN `pFecha` DATE, IN `pIdVendedor` INT(11), IN `pIdContacto` INT(11))  NO SQL
BEGIN
SET @precio = getPrecioProducto(pIdProducto);
SET @precioFinal = @precio - (@precio  * (pDescuento/100));
SET @comision = @precioFinal * (pPorcentajeComision/100);
INSERT INTO venta (idVenta, idProducto, descuento, porcentajeComision, fecha, precioFinal, comision, idVendedor, idContacto) 
VALUES (null, pIdProducto, pDescuento, pPorcentajeComision, pFecha, @precioFinal, @comision, pIdVendedor, pIdContacto);
COMMIT;
END$$

DROP PROCEDURE IF EXISTS `updateRespuestaPropuestaVenta`$$
CREATE DEFINER=`root`@`%` PROCEDURE `updateRespuestaPropuestaVenta` (IN `pEstado` VARCHAR(200), IN `pFecha` DATE, IN `pRespuesta` VARCHAR(200), IN `pIDPropuesta` INT)  NO SQL
UPDATE respuestadepropuesta 
SET estado = pEstado, fecha = pFecha, respuesta = pRespuesta
WHERE idPropuestaVenta = pIDPropuesta$$

--
-- Functions
--
DROP FUNCTION IF EXISTS `getPrecioProducto`$$
CREATE DEFINER=`root`@`%` FUNCTION `getPrecioProducto` (`pIdProducto` INT(11)) RETURNS INT(11) NO SQL
    DETERMINISTIC
BEGIN
SELECT precio
INTO @precio
FROM producto
WHERE idProducto = pIdProducto;
RETURN @precio;
END$$

DROP FUNCTION IF EXISTS `insertEntidad`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `insertEntidad` (`pIdUsuario` INT(11)) RETURNS INT(255) NO SQL
BEGIN
insert into entidad(idEntidad, idUsuarioEntidad) values (null, pIdUsuario);
RETURN LAST_INSERT_ID();
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `correo`
--

DROP TABLE IF EXISTS `correo`;
CREATE TABLE `correo` (
  `idCorreo` int(11) NOT NULL,
  `descripcionCorreo` varchar(45) NOT NULL,
  `idPersonaCorreo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `direccion`
--

DROP TABLE IF EXISTS `direccion`;
CREATE TABLE `direccion` (
  `idDireccion` int(11) NOT NULL,
  `descripcionDireccion` varchar(1000) NOT NULL,
  `idEntidadDireccion` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `empresa`
--

DROP TABLE IF EXISTS `empresa`;
CREATE TABLE `empresa` (
  `idEmpresa` int(11) NOT NULL,
  `descripcionEmpresa` varchar(45) NOT NULL,
  `idEntidadEmpresa` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `entidad`
--

DROP TABLE IF EXISTS `entidad`;
CREATE TABLE `entidad` (
  `idEntidad` int(11) NOT NULL,
  `idUsuarioEntidad` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `persona`
--

DROP TABLE IF EXISTS `persona`;
CREATE TABLE `persona` (
  `idPersona` int(11) NOT NULL,
  `nombrePersona` varchar(45) NOT NULL,
  `apellido1Persona` varchar(45) NOT NULL,
  `apellido2Persona` varchar(45) DEFAULT NULL,
  `descripcionEmpresaPersona` varchar(45) DEFAULT NULL,
  `idEntidadPersona` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
CREATE TABLE `producto` (
  `idProducto` int(11) NOT NULL,
  `nombre` varchar(200) NOT NULL,
  `precio` int(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `propuestaventa`
--

DROP TABLE IF EXISTS `propuestaventa`;
CREATE TABLE `propuestaventa` (
  `idPropuestaVenta` int(11) NOT NULL,
  `productoPropuestaVenta` int(45) NOT NULL,
  `fechaPropuestaVenta` date NOT NULL,
  `precio` int(11) NOT NULL,
  `idVendedor` int(11) NOT NULL,
  `idContacto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `respuestadepropuesta`
--

DROP TABLE IF EXISTS `respuestadepropuesta`;
CREATE TABLE `respuestadepropuesta` (
  `idRespuestaDePropuesta` int(11) NOT NULL,
  `idPropuestaVenta` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `respuesta` varchar(200) NOT NULL DEFAULT 'No especificada.',
  `estado` varchar(200) NOT NULL DEFAULT 'Sin respuesta.'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `telefono`
--

DROP TABLE IF EXISTS `telefono`;
CREATE TABLE `telefono` (
  `idTelefono` int(11) NOT NULL,
  `descripcionTelefono` varchar(45) NOT NULL,
  `idEntidadTelefono` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario` (
  `idUsuario` int(11) NOT NULL,
  `descripcionUsuario` varchar(45) NOT NULL,
  `contrasenaUsuario` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `venta`
--

DROP TABLE IF EXISTS `venta`;
CREATE TABLE `venta` (
  `idVenta` int(11) NOT NULL,
  `idProducto` int(11) NOT NULL,
  `descuento` int(11) NOT NULL,
  `porcentajeComision` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `precioFinal` int(11) NOT NULL,
  `comision` int(11) NOT NULL,
  `idVendedor` int(11) NOT NULL,
  `idContacto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `correo`
--
ALTER TABLE `correo`
  ADD PRIMARY KEY (`idCorreo`),
  ADD UNIQUE KEY `idCorreo_UNIQUE` (`idCorreo`),
  ADD KEY `fk_Correo_Persona2_idx` (`idPersonaCorreo`);

--
-- Indexes for table `direccion`
--
ALTER TABLE `direccion`
  ADD PRIMARY KEY (`idDireccion`,`idEntidadDireccion`),
  ADD UNIQUE KEY `idDireccion_UNIQUE` (`idDireccion`),
  ADD KEY `fk_Direccion_Entidad1_idx` (`idEntidadDireccion`);

--
-- Indexes for table `empresa`
--
ALTER TABLE `empresa`
  ADD PRIMARY KEY (`idEmpresa`,`idEntidadEmpresa`),
  ADD UNIQUE KEY `idEmpresa_UNIQUE` (`idEmpresa`),
  ADD UNIQUE KEY `idEntidadEmpresa_UNIQUE` (`idEntidadEmpresa`),
  ADD KEY `fk_Empresa_Entidad1_idx` (`idEntidadEmpresa`);

--
-- Indexes for table `entidad`
--
ALTER TABLE `entidad`
  ADD PRIMARY KEY (`idEntidad`,`idUsuarioEntidad`),
  ADD UNIQUE KEY `idEntidad_UNIQUE` (`idEntidad`),
  ADD KEY `fk_Entidad_Usuario1_idx` (`idUsuarioEntidad`);

--
-- Indexes for table `persona`
--
ALTER TABLE `persona`
  ADD PRIMARY KEY (`idPersona`,`idEntidadPersona`),
  ADD UNIQUE KEY `idPersona_UNIQUE` (`idPersona`),
  ADD UNIQUE KEY `idEntidadPersona_UNIQUE` (`idEntidadPersona`),
  ADD KEY `fk_Persona_Empresa1_idx` (`descripcionEmpresaPersona`),
  ADD KEY `fk_Persona_Entidad1_idx` (`idEntidadPersona`);

--
-- Indexes for table `producto`
--
ALTER TABLE `producto`
  ADD PRIMARY KEY (`idProducto`);

--
-- Indexes for table `propuestaventa`
--
ALTER TABLE `propuestaventa`
  ADD PRIMARY KEY (`idPropuestaVenta`),
  ADD KEY `productoPropuestaVenta` (`productoPropuestaVenta`),
  ADD KEY `idVendedor` (`idVendedor`),
  ADD KEY `idContacto` (`idContacto`);

--
-- Indexes for table `respuestadepropuesta`
--
ALTER TABLE `respuestadepropuesta`
  ADD PRIMARY KEY (`idRespuestaDePropuesta`),
  ADD KEY `idPropuestaVenta` (`idPropuestaVenta`);

--
-- Indexes for table `telefono`
--
ALTER TABLE `telefono`
  ADD PRIMARY KEY (`idTelefono`),
  ADD UNIQUE KEY `idTelefono_UNIQUE` (`idTelefono`),
  ADD KEY `fk_Telefono_Entidad1_idx` (`idEntidadTelefono`);

--
-- Indexes for table `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`idUsuario`),
  ADD UNIQUE KEY `idUsuario_UNIQUE` (`idUsuario`),
  ADD UNIQUE KEY `descripcionUsuario_UNIQUE` (`descripcionUsuario`);

--
-- Indexes for table `venta`
--
ALTER TABLE `venta`
  ADD PRIMARY KEY (`idVenta`),
  ADD KEY `idProducto` (`idProducto`),
  ADD KEY `idVendedor` (`idVendedor`),
  ADD KEY `idContacto` (`idContacto`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `correo`
--
ALTER TABLE `correo`
  MODIFY `idCorreo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `direccion`
--
ALTER TABLE `direccion`
  MODIFY `idDireccion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `empresa`
--
ALTER TABLE `empresa`
  MODIFY `idEmpresa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `entidad`
--
ALTER TABLE `entidad`
  MODIFY `idEntidad` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT for table `persona`
--
ALTER TABLE `persona`
  MODIFY `idPersona` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `producto`
--
ALTER TABLE `producto`
  MODIFY `idProducto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `propuestaventa`
--
ALTER TABLE `propuestaventa`
  MODIFY `idPropuestaVenta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `respuestadepropuesta`
--
ALTER TABLE `respuestadepropuesta`
  MODIFY `idRespuestaDePropuesta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `telefono`
--
ALTER TABLE `telefono`
  MODIFY `idTelefono` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `usuario`
--
ALTER TABLE `usuario`
  MODIFY `idUsuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `venta`
--
ALTER TABLE `venta`
  MODIFY `idVenta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `correo`
--
ALTER TABLE `correo`
  ADD CONSTRAINT `fk_Correo_Persona2` FOREIGN KEY (`idPersonaCorreo`) REFERENCES `persona` (`idPersona`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `direccion`
--
ALTER TABLE `direccion`
  ADD CONSTRAINT `fk_Direccion_Entidad1` FOREIGN KEY (`idEntidadDireccion`) REFERENCES `entidad` (`idEntidad`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `empresa`
--
ALTER TABLE `empresa`
  ADD CONSTRAINT `fk_Empresa_Entidad1` FOREIGN KEY (`idEntidadEmpresa`) REFERENCES `entidad` (`idEntidad`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `entidad`
--
ALTER TABLE `entidad`
  ADD CONSTRAINT `fk_Entidad_Usuario1` FOREIGN KEY (`idUsuarioEntidad`) REFERENCES `usuario` (`idUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `persona`
--
ALTER TABLE `persona`
  ADD CONSTRAINT `fk_Persona_Entidad1` FOREIGN KEY (`idEntidadPersona`) REFERENCES `entidad` (`idEntidad`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `propuestaventa`
--
ALTER TABLE `propuestaventa`
  ADD CONSTRAINT `fkProductoPropuestaVenta` FOREIGN KEY (`productoPropuestaVenta`) REFERENCES `producto` (`idProducto`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fkVendedor` FOREIGN KEY (`idVendedor`) REFERENCES `usuario` (`idUsuario`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `propuestaventa_ibfk_1` FOREIGN KEY (`idContacto`) REFERENCES `entidad` (`idEntidad`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `respuestadepropuesta`
--
ALTER TABLE `respuestadepropuesta`
  ADD CONSTRAINT `fkPropuestaVenta` FOREIGN KEY (`idPropuestaVenta`) REFERENCES `propuestaventa` (`idPropuestaVenta`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `telefono`
--
ALTER TABLE `telefono`
  ADD CONSTRAINT `fk_Telefono_Entidad1` FOREIGN KEY (`idEntidadTelefono`) REFERENCES `entidad` (`idEntidad`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `venta`
--
ALTER TABLE `venta`
  ADD CONSTRAINT `fkIdContacto` FOREIGN KEY (`idContacto`) REFERENCES `entidad` (`idEntidad`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `vendedor_ibfk_1` FOREIGN KEY (`idVendedor`) REFERENCES `usuario` (`idUsuario`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `venta_ibfk_1` FOREIGN KEY (`idProducto`) REFERENCES `producto` (`idProducto`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
