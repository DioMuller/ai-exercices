require "libs/case"
require "libs/math"

-- Dracula States
BossState = 
{
	STATE_INITIAL = { description = "Initial", vulnerable = false, sprite_normal = "assets/sprites/dracula_initial.png", sprite_monster = "assets/sprites/missing.png", sfx_normal = "assets/sounds/default.wav", sfx_monster = "assets/sounds/default.wav" },
	STATE_WAITING = { description = "Waiting", vulnerable = true, sprite_normal = "assets/sprites/dracula_waiting.png", sprite_monster = "assets/sprites/monster_waiting.png", sfx_normal = "assets/sounds/state_normal_waiting.wav", sfx_monster = "assets/sounds/default.wav" },
	STATE_BEINGHIT = { description = "Being Hit", vulnerable = false, sprite_normal = "assets/sprites/dracula_beinghit.png", sprite_monster = "assets/sprites/monster_beinghit.png", sfx_normal = "assets/sounds/state_beinghit.wav", sfx_monster = "assets/sounds/state_beinghit.wav" },
	STATE_NORMAL_FIREBALL = { description = "Throwing Fireball (As Dracula)", vulnerable = true, sprite_normal = "assets/sprites/dracula_fireball.png", sprite_monster = "assets/sprites/missing.png", sfx_normal = "assets/sounds/state_normal_fireball.wav", sfx_monster = "assets/sounds/default.wav" },
	STATE_NORMAL_ENERGYBALL = { description = "Throwing Energy Ball (As Dracula)", vulnerable = true, sprite_normal = "assets/sprites/dracula_energyball.png", sprite_monster = "assets/sprites/missing.png", sfx_normal = "assets/sounds/state_normal_energyball.wav", sfx_monster = "assets/sounds/default.wav" },
	STATE_NORMAL_TELEPORT_IN = { description = "Teleporting (In) (As Dracula)", vulnerable = false, sprite_normal = "assets/sprites/dracula_teleport.png", sprite_monster = "assets/sprites/missing.png", sfx_normal = "assets/sounds/state_normal_teleport_in.wav", sfx_monster = "assets/sounds/default.wav"  },
	STATE_NORMAL_TELEPORT_OUT = { description = "Teleporting (Out) (As Dracula)", vulnerable = false, sprite_normal = "assets/sprites/dracula_teleport.png", sprite_monster = "assets/sprites/missing.png", sfx_normal = "assets/sounds/state_normal_teleport_out.wav", sfx_monster = "assets/sounds/default.wav"   },
	STATE_NORMAL_TRANSFORMING = { description = "Transforming into monster (As Dracula)", vulnerable = false, sprite_normal = "assets/sprites/dracula_transforming.png", sprite_monster = "assets/sprites/missing.png", sfx_normal = "assets/sounds/state_normal_transforming.wav", sfx_monster = "assets/sounds/default.wav"  },
	STATE_MONSTER_DECIDING = { description = "Deciding next move (As Monster)", vulnerable = true, sprite_normal = "assets/sprites/missing.png", sprite_monster = "assets/sprites/monster_waiting.png", sfx_normal = "assets/sounds/default.wav", sfx_monster = "assets/sounds/default.wav"  },
	STATE_MONSTER_JUMPING = { description = "Jumping (As Monster)", vulnerable = true, sprite_normal = "assets/sprites/missing.png", sprite_monster = "assets/sprites/monster_jumping.png", sfx_normal = "assets/sounds/default.wav", sfx_monster = "assets/sounds/state_monster_jump.wav" },
	STATE_MONSTER_FIREBREATH = { description = "Throwing Fireball (As Monster)", vulnerable = true, sprite_normal = "assets/sprites/missing.png", sprite_monster = "assets/sprites/monster_fireball.png", sfx_normal = "assets/sounds/default.wav", sfx_monster = "assets/sounds/state_monster_fireball.wav" },
	STATE_MONSTER_DYING = { description = "Dying (As Monster)", vulnerable = false, sprite_normal = "assets/sprites/missing.png", sprite_monster = "assets/sprites/monster_dying.png", sfx_normal = "assets/sounds/default.wav", sfx_monster = "assets/sounds/state_monster_dying.wav" },
	STATE_DEAD = { description = "Dead!", vulnerable = false, sprite_normal = "assets/sprites/missing.png", sprite_monster = "assets/sprites/monster_dead.png", sfx_normal = "assets/sounds/default.wav", sfx_monster = "assets/sounds/default.wav" }
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
	x_offset = 0.0
}

function initializeBossStates()
	for key, value in pairs(BossState) do
		-- Normal Assets
		BossState[key].image_normal = love.graphics.newImage(BossState[key].sprite_normal)
		BossState[key].origin_normal = 
			{ 
				x = BossState[key].image_normal.getWidth(BossState[key].image_normal) / 2, 
				y = BossState[key].image_normal.getHeight(BossState[key].image_normal) / 2 
			}
		BossState[key].sound_normal = love.audio.newSource(BossState[key].sfx_normal, "static")
			
		-- Monster Assets		
		BossState[key].image_monster = love.graphics.newImage(BossState[key].sprite_monster)
		BossState[key].origin_monster = 
			{ 
				x = BossState[key].image_monster.getWidth(BossState[key].image_monster) / 2, 
				y = BossState[key].image_monster.getHeight(BossState[key].image_monster) / 2 
			}
		BossState[key].sound_monster = love.audio.newSource(BossState[key].sfx_monster, "static")
	end
end

function updateBoss(dt)
	boss.wait_time = boss.wait_time - dt;

	if( boss.wait_time <= 0 ) then
		switch(boss.current_state) 
		{
			[BossState.STATE_INITIAL] =
				function()
					boss.current_state = BossState.STATE_NORMAL_TELEPORT_IN
					boss.wait_time = 1.0
				end,
			[BossState.STATE_WAITING] =
				function()
					if boss.is_moster then						
						boss.current_state = BossState.STATE_MONSTER_DECIDING
					else
						boss.current_state = BossState.STATE_NORMAL_TELEPORT_OUT
					end
					boss.wait_time = 1.0
				end,
			[BossState.STATE_BEINGHIT] =
				function()
					boss.hp = boss.hp - 1
					
					if not boss.is_moster and boss.hp <= 5 then -- Transforms at half HP.
						boss.current_state = BossState.STATE_NORMAL_TRANSFORMING
					elseif boss.hp <= 0 then
						boss.current_state = BossState.STATE_MONSTER_DYING
						boss.wait_time = 3.0
					else
						boss.current_state = boss.last_state
						boss.wait_time = boss.remaining_time
					end
				end,
			[BossState.STATE_NORMAL_FIREBALL] =
				function()
					boss.current_state = BossState.STATE_WAITING
					boss.wait_time = 1.0
				end,
			[BossState.STATE_NORMAL_ENERGYBALL] =
				function()
					boss.current_state = BossState.STATE_WAITING
					boss.wait_time = 1.0
				end,
			[BossState.STATE_NORMAL_TELEPORT_OUT] =
				function()
					boss.current_state = BossState.STATE_NORMAL_TELEPORT_IN
					boss.x_offset = 300 - math.random() * 600
					boss.wait_time = 1.0
				end,
			[BossState.STATE_NORMAL_TELEPORT_IN] =
				function()
					if math.random() > 0.7	then
						boss.current_state = BossState.STATE_NORMAL_ENERGYBALL
					else
						boss.current_state = BossState.STATE_NORMAL_FIREBALL
					end
					boss.wait_time = 2.0
				end,
			[BossState.STATE_NORMAL_TRANSFORMING] =
				function()
					boss.is_moster = true
					boss.current_state = BossState.STATE_MONSTER_DECIDING
					boss.wait_time = 3.0
				end,
			[BossState.STATE_MONSTER_DECIDING] =
				function()
					if math.random() > 0.6	then
						boss.current_state = BossState.STATE_MONSTER_JUMPING
					else
						boss.current_state = BossState.STATE_MONSTER_FIREBREATH
					end
					boss.wait_time = 0.5
				end,
			[BossState.STATE_MONSTER_JUMPING] =
				function()
					boss.current_state = BossState.STATE_WAITING
					boss.wait_time = 3.0
				end,
			[BossState.STATE_MONSTER_FIREBREATH] =
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

		-- Play state sound effect.
		if not boss.is_moster then
			boss.current_state.sound_normal:play()
		else
			boss.current_state.sound_monster:play()
		end
	end
end

function drawState(x, y, scaleX, scaleY)
	if boss.is_moster then
		love.graphics.draw(boss.current_state.image_monster, boss.x_offset + x - boss.current_state.origin_monster.x, y - boss.current_state.origin_monster.y, 0, scaleX, scaleY)
	else
		love.graphics.draw(boss.current_state.image_normal, boss.x_offset + x - boss.current_state.origin_normal.x, y - boss.current_state.origin_normal.y, 0, scaleX, scaleY, scaleY)
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