<?php
	include_once "DBConfig.php";
	class Crud extends DBConfig
	{
		
		function __construct()
		{
			parent::__construct();
		}

		public function getData($query){
			$result = $this->connection->query($query);
			if(!$result)
				return false;
			$rows = array();
			foreach ($row = $result->fetch_assoc()) {
				$rows[] = $row;
			}
			return $rows;
		}
		public function execute($query){
			$result = 
		}
	}
?>