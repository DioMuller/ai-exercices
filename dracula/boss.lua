require "libs/case"
require "libs/math"

-- Dracula States
BossState = 
{
	STATE_INITIAL = { description = "Initial", vulnerable = false },
	STATE_WAITING = { description = "Waiting", vulnerable = true },
	STATE_BEINGHIT = { description = "Being Hit", vulnerable = false },
	STATE_NORMAL_FIREBALL = { description = "Throwing Fireball (As Dracula)", vulnerable = true },
	STATE_NORMAL_ENERGYBALL = { description = "Throwing Energy Ball (As Dracula)", vulnerable = true },
	STATE_NORMAL_TELEPORT = { description = "Teleporting (As Dracula)", vulnerable = false },
	STATE_NORMAL_TRANSFORMING = { description = "Transforming into monster (As Dracula)", vulnerable = false },
	STATE_MONSTER_DECIDING = { description = "Deciding next move (As Monster)", vulnerable = true },
	STATE_MONSTER_JUMPING = { description = "Jumping (As Monster)", vulnerable = true },
	STATE_MONSTER_FIREBALL = { description = "Throwing Fireball (As Monster)", vulnerable = true },
	STATE_MONSTER_DYING = { description = "Dying (As Monster)", vulnerable = false },
	STATE_DEAD = { description = "Dead!", vulnerable = false }
}

-- Boss Declaration
boss = 
{
	hp = 10,
	is_moster = false,
	wait_time = 1.0,
	current_state = BossState.STATE_INITIAL,
	last_state = BossState.STATE_INITIAL,
	remaining_time = 0.0,
}

function updateBoss(dt)
	boss.wait_time = boss.wait_time - dt;

	if( boss.wait_time <= 0 ) then
		switch(boss.current_state) 
		{
			[BossState.STATE_INITIAL] =
				function()
					boss.current_state = BossState.STATE_NORMAL_TELEPORT
					wait_time = 1.0
				end,
			[BossState.STATE_WAITING] =
				function()
					if boss.is_moster then						
						boss.current_state = BossState.STATE_MONSTER_DECIDING
					else
						boss.current_state = BossState.STATE_NORMAL_TELEPORT
					end
					boss.wait_time = 1.0
				end,
			[BossState.STATE_BEINGHIT] =
				function()
					boss.hp = boss.hp - 1
					
					if boss.hp <= 5 then -- Transforms at half HP.
						boss.current_state = BossState.STATE_NORMAL_TRANSFORMING
					elseif boss.hp <= 0 then
						boss.current_state = BossState.STATE_DEAD
					else
						boss.current_state = boss.last_state
						boss.wait_time = boss.remaining_time
					end
				end,
			[BossState.STATE_NORMAL_FIREBALL] =
				function()
					boss.current_state = BossState.STATE_WAITING
					boss.wait_time = 3.0
				end,
			[BossState.STATE_NORMAL_ENERGYBALL] =
				function()
					boss.current_state = BossState.STATE_WAITING
					boss.wait_time = 3.0
				end,
			[BossState.STATE_NORMAL_TELEPORT] =
				function()
					if math.random() > 0.7	then
						boss.current_state = BossState.STATE_NORMAL_ENERGYBALL
					else
						boss.current_state = BossState.STATE_NORMAL_FIREBALL
					end
					boss.wait_time = 1.0
				end,
			[BossState.STATE_NORMAL_TRANSFORMING] =
				function()
					boss.is_moster = true
					boss.current_state = BossState.STATE_MONSTER_DECIDING
					boss.wait_time = 1.0
				end,
			[BossState.STATE_MONSTER_DECIDING] =
				function()
					if math.random() > 0.6	then
						boss.current_state = BossState.STATE_MONSTER_JUMPING
					else
						boss.current_state = BossState.STATE_MONSTER_FIREBALL
					end
					boss.wait_time = 1.0
				end,
			[BossState.STATE_MONSTER_JUMPING] =
				function()
					boss.current_state = BossState.STATE_WAITING
					boss.wait_time = 3.0
				end,
			[BossState.STATE_MONSTER_FIREBALL] =
				function()
					boss.current_state = BossState.STATE_WAITING
					boss.wait_time = 3.0
				end,
			[BossState.STATE_MONSTER_DYING] =
				function()
					boss.current_state = BossState.STATE_DEAD
					boss.wait_time = 5.0
				end,
			[BossState.STATE_DEAD] =
				function()
					boss.current_state = BossState.STATE_DEAD
					boss.wait_time = 5.0
				end,
			[Default] =
				function()
				end,
			[Nil] =
				function()
				end
		}
	end
end

function attackBoss()
	if boss.current_state.vulnerable then
		boss.last_state = boss.current_state
		boss.remaining_time = boss.wait_time
		boss.current_state = BossState.STATE_BEINGHIT
		boss.wait_time = 1.0
	end
end